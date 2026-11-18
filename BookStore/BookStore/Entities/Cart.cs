namespace BookStore.Entities;

public class Cart
{
    // The books a customer plans to buy before checkout.
    public int Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public ICollection<CartItem> Items { get; set; } = [];
}


