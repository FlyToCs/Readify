

using Readify.Domain.Core._common.Entities;

namespace Readify.Domain.Core.Category.Entities;

public class Category : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
    public List<Book.Entities.Book> Books { get; set; } = [];
    public int UserId { get; set; }
    public User.Entities.User User { get; set; }

}