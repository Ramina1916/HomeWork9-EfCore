namespace BookStore.DTOs;

public record BookDto(
    int Id,
    string Title,
    string? Isbn,
    string? Description,
    decimal Price,
    int Stock,
    int? PageCount,
    int? PublishedYear,
    string? CoverImageUrl,
    DateTimeOffset CreatedAt);