using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Readify.Domain.Core.Book.Entities;

namespace Readify.Infa.Db.SqlServer.EfCore.Configs;

public class BookImgConfigurations : IEntityTypeConfiguration<BookImg>
{
    public void Configure(EntityTypeBuilder<BookImg> builder)
    {
        builder.HasKey(img => img.Id);
        builder.Property(img => img.ImageUrl).HasMaxLength(250);

    }
}