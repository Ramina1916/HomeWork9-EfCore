using BookStore.DTOs;

namespace BookStore.Services
{
    public interface IBookService
    {
        Task<BookDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<(BookDto Book, bool Created)> AddAsync(CreateBookDto dto, CancellationToken cancellationToken = default);
    }
}
