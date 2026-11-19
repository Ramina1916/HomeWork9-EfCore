namespace BookStore.DTOs;

using System.ComponentModel.DataAnnotations;

public class UpdateBookDto
{
    [Required]
    [StringLength(200)]
    public string Title { get; init; } = string.Empty;

    [StringLength(20)]
    public string? Isbn { get; init; }

    [StringLength(2000)]
    public string? Description { get; init; }

    [Range(0.01, 100000.0)]
    public decimal Price { get; init; }

    [Required]
    [Range(0, int.MaxValue)]
    public int? Stock { get; init; }

    [Range(1, 10000)]
    public int? PageCount { get; init; }

    [Range(1000, 2100)]
    public int? PublishedYear { get; init; }

    [Url]
    [StringLength(500)]
    public string? CoverImageUrl { get; init; }
}
