namespace BookStore.Entities;

public class Category
{
    // A genre or topic used to group books, with an optional parent category.
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }

    public int? ParentId { get; set; }
    public Category? Parent { get; set; }
    public ICollection<Category> Children { get; set; } = [];

    public ICollection<Book> Books { get; set; } = [];
}


