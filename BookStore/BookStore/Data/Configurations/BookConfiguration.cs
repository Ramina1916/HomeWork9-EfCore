using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(b => b.Title).HasMaxLength(200);
        builder.HasIndex(b => b.Title).IsUnique();

        builder.Property(b => b.Isbn).HasMaxLength(20);
        builder.HasIndex(b => b.Isbn).IsUnique();

        builder.Property(b => b.Description).HasMaxLength(2000);
        builder.Property(b => b.CoverImageUrl).HasMaxLength(500);
        builder.Property(b => b.Price).HasPrecision(18, 2);
        builder.Property(b => b.CreatedAt).HasDefaultValueSql("SYSDATETIMEOFFSET()");
    }
}