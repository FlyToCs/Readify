using System.Security.AccessControl;
using Readify.Domain.Core.Book.Entities;

namespace Readify.Domain.Core.Book.DTOs;

public class GetBookDto
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public BookImg img { get; set; } 
    public string BookName { get; set; }
    public decimal Price { get; set; }
    public string AuthorName { get; set; }
    public int PageCount { get; set; }
}