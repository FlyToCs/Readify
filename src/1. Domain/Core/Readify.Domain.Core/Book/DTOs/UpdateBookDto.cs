using Microsoft.AspNetCore.Http;

namespace Readify.Domain.Core.Book.DTOs;

public class UpdateBookDto
{
    public int BookId { get; set; }
    public int CategoryId { get; set; }
    public IFormFile? ImgFile { get; set; }
    public string? ImgUrl { get; set; }
    public string BookName { get; set; }
    public decimal Price { get; set; }
    public string AuthorName { get; set; }
    public int PageCount { get; set; }
    public int UserId { get; set; }
}