using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Readify.Domain.Core.User.Entities;

namespace Readify.Infa.Db.SqlServer.EfCore.Configs;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.FirstName).HasMaxLength(100);
        builder.Property(u => u.LastName).HasMaxLength(100);
        builder.Property(u => u.ImgUrl).HasMaxLength(150);
        builder.Property(u => u.UserName).HasMaxLength(50); 
        builder.Property(u => u.HashedPassword).HasMaxLength(200);

        builder.Property(c => c.CreatedAt).HasDefaultValueSql("GetDate()")
            .ValueGeneratedOnAdd();

        builder.HasMany(u => u.Books).WithOne(b => b.User).HasForeignKey(b => b.UserId);
        builder.HasMany(u => u.Categories).WithOne(c => c.User).HasForeignKey(c => c.UserId);


    }
}