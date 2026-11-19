namespace BookStore.Entities;

public class CartItem
{
    // One book and its quantity inside a cart.
    public int Id { get; set; }
    public int Quantity { get; set; } = 1;

    public int CartId { get; set; }
    public Cart Cart { get; set; } = null!;

    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
}


