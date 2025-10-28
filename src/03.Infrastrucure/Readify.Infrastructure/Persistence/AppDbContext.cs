using Microsoft.EntityFrameworkCore;
using Readify.Domain.BookAgg.Entities;
using Readify.Domain.CategoryAgg.Entities;
using Readify.Infrastructure.Configuration;

namespace Readify.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<BookImg> BookImgs { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookConfigurations).Assembly);
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
}