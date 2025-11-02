namespace Readify.UI_MVC.Models
{
    public class CreateCategoryViewModel 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile? ImgFile { get; set; }
        public string? ImgUrl { get; set; }
    }
}
