using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(order => order.Status)
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.HasOne(order => order.Customer)
            .WithMany(customer => customer.Orders)
            .HasForeignKey(order => order.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(order => order.ShippingAddress)
            .WithMany()
            .HasForeignKey(order => order.ShippingAddressId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(order => order.OrderDate).HasDefaultValueSql("SYSDATETIMEOFFSET()");
    }
}
