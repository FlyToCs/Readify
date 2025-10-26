using Readify.Domain._common.Entities;

namespace Readify.Domain.BookAgg.Entities;

public class Book : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string AuthorName { get; set; }
    public decimal Price { get; set; }
    public string ImgUrl { get; set; }
    public int PageCount { get; set; }


    public int CategoryId { get; set; }
    public Category Category { get; set; }

}