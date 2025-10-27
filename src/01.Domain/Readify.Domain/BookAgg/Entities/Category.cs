using Readify.Domain._common.Entities;

namespace Readify.Domain.BookAgg.Entities;

public class Category : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
    public List<Book> Books { get; set; }
}