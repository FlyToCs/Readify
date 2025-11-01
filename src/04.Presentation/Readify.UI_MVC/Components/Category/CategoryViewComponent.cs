using Microsoft.AspNetCore.Mvc;
using Readify.Domain.CategoryAgg.Contracts.ServiceContracts;
using Readify.Domain.CategoryAgg.DTOs;
using Readify.Services;

namespace Readify.UI_MVC.Components.Category
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
