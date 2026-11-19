namespace BookStore.Entities;

public class Address
{
    // A delivery address saved by a customer.
    public int Id { get; set; }
    public required string Street { get; set; }
    public required string City { get; set; }
    public string? State { get; set; }
    public required string PostalCode { get; set; }
    public required string Country { get; set; }
    public bool IsDefault { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
}


