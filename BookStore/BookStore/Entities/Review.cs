namespace BookStore.Entities;

public class Review
{
    // A customer's rating and comment on a book.
    public int Id { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public DateTimeOffset CreatedAt { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; } = null!;

    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
}