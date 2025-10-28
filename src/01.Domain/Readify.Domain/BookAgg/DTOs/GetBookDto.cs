using System.Security.AccessControl;
using Readify.Domain.BookAgg.Entities;

namespace Readify.Domain.BookAgg.DTOs;

public class GetBookDto
{
    public List<BookImg> images { get; set; } = [];
    public string BookName { get; set; }
    public decimal Price { get; set; }
    public string AuthorName { get; set; }
    public int PageCount { get; set; }
}