using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;
using Readify.Domain.BookAgg.Contracts.ServiceContracts;
using Readify.Domain.BookAgg.DTOs;
using Readify.Domain.CategoryAgg.Contracts.ServiceContracts;

namespace Readify.UI_MVC.Controllers
{
    public class BookManagerController(IBookService bookService , ICategoryService categoryService) : Controller
    {
        public IActionResult Index()
        {
            var bookList = bookService.GetBooks();
            return View(bookList);
        }

        public IActionResult Create()
        {
            var categories = categoryService.GetCategories();
            return View(categories);
        }

        [HttpPost]
        public IActionResult Create(CreateBookDto createBook)
        {
            bookService.Create(createBook);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            return RedirectToAction("Index");
        }
    }
}
