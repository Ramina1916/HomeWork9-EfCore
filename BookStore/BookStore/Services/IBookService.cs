using BookStore.DTOs;

namespace BookStore.Services
{
    public interface IBookService
    {
        Task<BookDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<(BookDto Book, bool Created)> AddAsync(CreateBookDto dto, CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(int id, UpdateBookDto dto, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
