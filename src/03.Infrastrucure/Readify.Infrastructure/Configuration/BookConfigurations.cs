using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Readify.Domain.BookAgg.Entities;

namespace Readify.Infrastructure.Configuration;

public class BookConfigurations : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Name).HasMaxLength(400).IsRequired();
        builder.Property(b => b.AuthorName).HasMaxLength(100).IsRequired();
        builder.Property(b => b.Price).HasPrecision(10, 0);

        builder.Property(b => b.CreatedAt).HasDefaultValueSql("GetDate()")
            .ValueGeneratedOnAdd();

        builder.HasOne(b => b.Category)
            .WithMany(c => c.Books).HasForeignKey(b => b.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

    }
}