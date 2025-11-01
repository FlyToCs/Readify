using Readify.Domain._common.Entities;
using Readify.Domain.BookAgg.Entities;
using Readify.Domain.UserAgg.Entities;

namespace Readify.Domain.CategoryAgg.Entities;

public class Category : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
    public List<Book> Books { get; set; } = [];
    public int UserId { get; set; }
    public User User { get; set; }

}