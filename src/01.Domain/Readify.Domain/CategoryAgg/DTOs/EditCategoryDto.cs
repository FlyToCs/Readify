using Microsoft.AspNetCore.Http;

namespace Readify.Domain.CategoryAgg.DTOs;

public class EditCategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Descerption { get; set; }
    public IFormFile? ImgFile { get; set; }
    public string? ImgUrl { get; set; }
}