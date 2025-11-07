

using Readify.Domain.Core.Book.DTOs;
using Readify.Domain.Core.Category.DTOs;

namespace Readify.EndPoint.UI_MVC.Models
{
    public class BookEditViewModel
    {
        public UpdateBookDto Book { get; set; }     
        public List<GetCategoryDto> Categories { get; set; }  
    }
}
