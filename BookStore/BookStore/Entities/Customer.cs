namespace BookStore.Entities;

public class Customer
{
    // A person who buys books from the store.
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTimeOffset CreatedAt { get; set; }

    public Cart? Cart { get; set; }
    public ICollection<Address> Addresses { get; set; } = [];
    public ICollection<Order> Orders { get; set; } = [];
    public ICollection<Review> Reviews { get; set; } = [];
}


