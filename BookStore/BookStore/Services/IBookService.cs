using BookStore.DTOs;

namespace BookStore.Services
{
    public interface IBookService
    {
        Task<BookDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
