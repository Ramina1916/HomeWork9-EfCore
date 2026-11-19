namespace BookStore.Entities
{
    public enum OrderStatus
    {
        // The stages of an order, from placement to delivery or cancellation.
        Pending = 1,
        Paid = 2,
        Shipped = 3,
        Delivered = 4,
        Cancelled = 5
    }
}
