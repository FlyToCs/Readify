using System.Security.AccessControl;

namespace Readify.Domain.BookAgg.DTOs;

public class GetBookDto
{
    public string ImgUrl { get; set; }
    public string BookName { get; set; }
    public decimal Price { get; set; }
    public string AuthorName { get; set; }
    public int PageCount { get; set; }
}