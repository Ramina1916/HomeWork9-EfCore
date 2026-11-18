namespace BookStore.Entities;

public class Author
{
    // A person who writes one or more books.
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Biography { get; set; }
    public string? PhotoUrl { get; set; }

    public ICollection<Book> Books { get; set; } = [];
}


