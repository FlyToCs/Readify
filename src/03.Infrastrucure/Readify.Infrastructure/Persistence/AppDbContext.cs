using Microsoft.EntityFrameworkCore;
using Readify.Domain.BookAgg.Entities;
using Readify.Domain.CategoryAgg.Entities;
using Readify.Domain.UserAgg.Entities;
using Readify.Infrastructure.Configuration;

namespace Readify.Infrastructure.Persistence;

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