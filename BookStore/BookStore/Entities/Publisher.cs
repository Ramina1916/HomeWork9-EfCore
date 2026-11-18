namespace BookStore.Entities;

public class Publisher
{
    // A company that publishes books.
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Website { get; set; }

    public ICollection<Book> Books { get; set; } = [];
}


