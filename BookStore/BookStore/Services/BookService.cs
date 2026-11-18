using BookStore.Data;
using BookStore.DTOs;
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
}
