using Microsoft.AspNetCore.Mvc;
using Readify.Domain._common.Entities;
using Readify.Domain.CategoryAgg.Contracts.ServiceContracts;
using Readify.Domain.CategoryAgg.DTOs;
using Readify.UI_MVC.CustomAttribute;


namespace Readify.UI_MVC.Controllers
{
    [AdminAuthorize]
    public class CategoryManagerController(ICategoryService categoryService) : Controller
    {
        
        public IActionResult Index()
        {
            var categoryList = categoryService.GetCategories();
            return View(categoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryDto model)
        {
            model.UserId =  HttpContext.Session.GetInt32("UserId")!.Value;
            var result = categoryService.Create(model);

            if (!result.IsSuccess)
            {
                ViewBag.Error = result.Message;
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
