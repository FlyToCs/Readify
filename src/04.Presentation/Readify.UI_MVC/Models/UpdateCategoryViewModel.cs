using Readify.Domain.CategoryAgg.DTOs;

namespace Readify.UI_MVC.Models
{
    public class UpdateCategoryViewModel 
    {
        public int Id { get; set; }

        public CreateCategoryDto CreateCategoryDto { get; set; }
    }
}
