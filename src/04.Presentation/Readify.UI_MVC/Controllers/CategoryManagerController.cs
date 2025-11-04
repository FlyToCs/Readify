using Microsoft.AspNetCore.Mvc;
using Readify.Domain._common.Entities;
using Readify.Domain.CategoryAgg.Contracts.ServiceContracts;
using Readify.Domain.CategoryAgg.DTOs;
using Readify.Domain.CategoryAgg.Entities;
using Readify.UI_MVC.CustomAttribute;
using Readify.UI_MVC.Models;


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

        [HttpGet]
        public IActionResult Edit(int categoryId)
        {
            var category = categoryService.GetById(categoryId);
            if (category == null)
                return NotFound();

            var model = new EditCategoryDto
            {
                Id = category.Data.Id,
                Name = category.Data.Name,
                Descerption = category.Data.Description,
                ImgUrl = category.Data.ImgUrl
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult Edit(EditCategoryDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var dto = new CreateCategoryDto
            {
                Name = model.Name,
                Descerption = model.Descerption,
                ImgFile = model.ImgFile,
                ImgUrl = model.ImgUrl
            };

            var result = categoryService.Update(model.Id, dto);

            if (!result.IsSuccess)
            {
                ViewBag.Error = result.Message;
                return View(model);
            }

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int categoryId)
        {
            categoryService.Delete(categoryId);
            return RedirectToAction("Index");
        }
    }
}
