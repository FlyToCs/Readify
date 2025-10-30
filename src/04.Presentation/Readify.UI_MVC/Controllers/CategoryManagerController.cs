using Microsoft.AspNetCore.Mvc;
using Readify.Domain.CategoryAgg.Contracts.ServiceContracts;

namespace Readify.UI_MVC.Controllers
{
    public class CategoryManagerController(ICategoryService categoryService) : Controller
    {
        public IActionResult Index()
        {
            var categoryList = categoryService.GetCategories();
            return View(categoryList);
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
