using BookStore.Data;
using BookStore.DTOs;
using BookStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services;

public class BookService(BookStoreDbContext dbContext) : IBookService
{
    public Task<BookDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return dbContext.Books
            .AsNoTracking()
            .Where(book => book.Id == id)
            .Select(book => new BookDto(
                book.Id,
                book.Title,
                book.Isbn,
                book.Description,
                book.Price,
                book.Stock,
                book.PageCount,
                book.PublishedYear,
                book.CoverImageUrl,
                book.CreatedAt))
            .SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<(BookDto Book, bool Created)> AddAsync(CreateBookDto dto, CancellationToken cancellationToken = default)
    {
        var existingBook = await dbContext.Books
            .Where(book => book.Title == dto.Title ||
                (dto.Isbn != null && book.Isbn == dto.Isbn))
            .FirstOrDefaultAsync(cancellationToken);

        if (existingBook is not null)
        {
            existingBook.Stock++;
            await dbContext.SaveChangesAsync(cancellationToken);

            return (new BookDto(
                existingBook.Id,
                existingBook.Title,
                existingBook.Isbn,
                existingBook.Description,
                existingBook.Price,
                existingBook.Stock,
                existingBook.PageCount,
                existingBook.PublishedYear,
                existingBook.CoverImageUrl,
                existingBook.CreatedAt), false);
        }

        var book = new Book
        {
            Title = dto.Title,
            Isbn = dto.Isbn,
            Description = dto.Description,
            Price = dto.Price,
            PageCount = dto.PageCount,
            PublishedYear = dto.PublishedYear,
            CoverImageUrl = dto.CoverImageUrl,
            CreatedAt = DateTimeOffset.UtcNow
        };

        dbContext.Books.Add(book);
        await dbContext.SaveChangesAsync(cancellationToken);

        return (new BookDto(
        book.Id,
        book.Title,
        book.Isbn,
        book.Description,
        book.Price,
        book.Stock,
        book.PageCount,
        book.PublishedYear,
        book.CoverImageUrl,
        book.CreatedAt), true);
    }

    public async Task<bool> UpdateAsync(int id, UpdateBookDto dto, CancellationToken cancellationToken = default)
    {
        var existingBook = await dbContext.Books
            .Where(book => book.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

        if (existingBook is null)
        {
            return false;
        }

        existingBook.Title = dto.Title;
        existingBook.Isbn = dto.Isbn;
        existingBook.Description = dto.Description;
        existingBook.Price = dto.Price;
        existingBook.Stock = dto.Stock!.Value;
        existingBook.PageCount = dto.PageCount;
        existingBook.PublishedYear = dto.PublishedYear;
        existingBook.CoverImageUrl = dto.CoverImageUrl;

        await dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}

