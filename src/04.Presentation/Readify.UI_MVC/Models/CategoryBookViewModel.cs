using Readify.Domain.BookAgg.DTOs;
using Readify.Domain.CategoryAgg.DTOs;

namespace Readify.UI_MVC.Models
{
    public class CategoryBookViewModel
    {
        public List<GetBookDto> Books { get; set; }
        public List<GetCategoryDto> Categories { get; set; }
    }
}
