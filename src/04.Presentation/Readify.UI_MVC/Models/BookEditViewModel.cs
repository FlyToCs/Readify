using Readify.Domain.BookAgg.DTOs;
using Readify.Domain.CategoryAgg.DTOs;

namespace Readify.UI_MVC.Models
{
    public class BookEditViewModel
    {
        public GetBookDto Book { get; set; }     
        public List<GetCategoryDto> Categories { get; set; }  
    }
}
