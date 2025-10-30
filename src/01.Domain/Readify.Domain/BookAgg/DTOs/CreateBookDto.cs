using Microsoft.AspNetCore.Http;

namespace Readify.Domain.BookAgg.DTOs;

public class CreateBookDto
{
    public string Name { get; set; }
    public string AuthorName { get; set; }
    public decimal Price { get; set; }
    public IFormFile? ImageFile { get; set; }
    public string? ImageUrl { get; set; }
    public int CategoryId { get; set; }
    public int PageCount { get; set; }
}