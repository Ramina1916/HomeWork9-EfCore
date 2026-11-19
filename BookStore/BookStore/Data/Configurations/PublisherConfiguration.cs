using BookStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Data.Configurations;

public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(150);
        builder.HasIndex(p => p.Name).IsUnique();
        builder.Property(p => p.Website).HasMaxLength(300);
    }
}
