using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(c => c.FirstName).HasMaxLength(100);
        builder.Property(c => c.LastName).HasMaxLength(100);
        builder.Property(c => c.Email).HasMaxLength(256);
        builder.HasIndex(c => c.Email).IsUnique();
        builder.Property(c => c.PhoneNumber).HasMaxLength(20);

        builder.Property(c => c.CreatedAt).HasDefaultValueSql("SYSDATETIMEOFFSET()");
    }
}
