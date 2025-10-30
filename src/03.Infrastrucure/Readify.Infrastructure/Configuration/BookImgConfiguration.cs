using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Readify.Domain.BookAgg.Entities;

namespace Readify.Infrastructure.Configuration;

public class BookImgConfiguration : IEntityTypeConfiguration<BookImg>
{
    public void Configure(EntityTypeBuilder<BookImg> builder)
    {
        builder.HasKey(img => img.Id);
        builder.Property(img => img.ImageUrl).HasMaxLength(250);

    }
}