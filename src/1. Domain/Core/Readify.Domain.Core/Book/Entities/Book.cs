

using Readify.Domain.Core._common.Entities;

namespace Readify.Domain.Core.Book.Entities;

public class Book : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string AuthorName { get; set; }
    public decimal Price { get; set; }
    public int PageCount { get; set; }


    public int CategoryId { get; set; }
    public Category.Entities.Category Category { get; set; }
    public List<BookImg> BookImgs { get; set; } = [];
    public int UserId { get; set; }
    public User.Entities.User User { get; set; }

}