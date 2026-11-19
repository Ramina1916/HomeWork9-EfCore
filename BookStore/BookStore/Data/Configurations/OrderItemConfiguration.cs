using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.Property(item => item.UnitPrice).HasPrecision(18, 2);

        builder.HasOne(item => item.Book)
            .WithMany()
            .HasForeignKey(item => item.BookId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
