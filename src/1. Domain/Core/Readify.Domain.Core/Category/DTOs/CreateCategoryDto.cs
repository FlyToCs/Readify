

using Microsoft.AspNetCore.Http;

namespace Readify.Domain.Core.Category.DTOs
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public string Descerption { get; set; }
        public IFormFile? ImgFile { get; set; }
        public string? ImgUrl { get; set; }
        public int UserId { get; set; }

    }
}
