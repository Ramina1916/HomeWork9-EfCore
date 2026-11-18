namespace BookStore.Entities;

public class Book
{
    // A book for sale, with its price, stock and catalogue details.
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Isbn { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; } = 1;
    public int? PageCount { get; set; }
    public int? PublishedYear { get; set; }
    public string? CoverImageUrl { get; set; }
    public DateTimeOffset CreatedAt { get; set; }

    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    public int? PublisherId { get; set; }
    public Publisher? Publisher { get; set; }
    public ICollection<Author> Authors { get; set; } = [];
    public ICollection<Review> Reviews { get; set; } = [];
}


