
using Microsoft.EntityFrameworkCore;
using Readify.Domain.Core.Book.Entities;
using Readify.Domain.Core.Category.Entities;
using Readify.Domain.Core.User.Entities;
using Readify.Infa.Db.SqlServer.EfCore.Configs;

namespace Readify.Infa.Db.SqlServer.EfCore.DbContexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<BookImg> BookImgs { get; set; }
    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookConfigurations).Assembly);
    }
}