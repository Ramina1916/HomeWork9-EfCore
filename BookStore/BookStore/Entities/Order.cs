namespace BookStore.Entities;

public class Order
{
    // A confirmed purchase placed by a customer.
    public int Id { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public int ShippingAddressId { get; set; }
    public Address ShippingAddress { get; set; } = null!;

    public ICollection<OrderItem> Items { get; set; } = [];
}
