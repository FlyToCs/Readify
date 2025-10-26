namespace Readify.Domain.BookAgg.DTOs;

public class CreateBookDto
{
    public string Name { get; set; }
    public string AuthorName { get; set; }
    public decimal Price { get; set; }
    public string ImgUrl { get; set; }
    public int CategoryId { get; set; }
}