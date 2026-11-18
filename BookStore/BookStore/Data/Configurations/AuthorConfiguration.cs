using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.Property(a => a.Name).HasMaxLength(150);
        builder.Property(a => a.Biography).HasMaxLength(2000);
        builder.Property(a => a.PhotoUrl).HasMaxLength(500);
    }
}
