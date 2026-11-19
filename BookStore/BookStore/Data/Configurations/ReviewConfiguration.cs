using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasIndex(review => new { review.BookId, review.CustomerId }).IsUnique();
        builder.Property(review => review.Comment).HasMaxLength(2000);
        builder.ToTable(table => table.HasCheckConstraint("CK_Reviews_Rating", "[Rating] BETWEEN 1 AND 5"));

        builder.Property(review => review.CreatedAt).HasDefaultValueSql("SYSDATETIMEOFFSET()");

    }
}
