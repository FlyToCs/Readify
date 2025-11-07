using Microsoft.AspNetCore.Mvc;
using Readify.Domain.Core.Category.Services;

namespace Readify.EndPoint.UI_MVC.Components.Category
{
    public class CategoryViewComponent(ICategoryService categoryService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var categories = categoryService.GetPopularCategories(5);
            return View("Categories", categories);
        }
    }
}
