using Microsoft.AspNetCore.Mvc;
using Readify.Domain.BookAgg.Contracts.ServiceContracts;
using Readify.Domain.BookAgg.DTOs;
using Readify.Domain.CategoryAgg.Contracts.ServiceContracts;
using Readify.Infrastructure.Repository;
using Readify.UI_MVC.CustomAttribute;

using Readify.UI_MVC.Models;
using System.Runtime.InteropServices.JavaScript;

namespace Readify.UI_MVC.Controllers
{
    public class BookManagerController(IBookService bookService , ICategoryService categoryService) : Controller
    {
        [AdminAuthorize]
        public IActionResult Index()
        {
            var bookList = bookService.GetBooks();
            return View(bookList);
        }
        [AdminAuthorize]
        public IActionResult Create()
        {
            var categories = categoryService.GetCategories();
            return View(categories);
        }

        [HttpPost]
        [AdminAuthorize]
        public IActionResult Create(CreateBookDto createBook)
        {
                createBook.UserId = HttpContext.Session.GetInt32("UserId")!.Value; 
                bookService.Create(createBook);
                return RedirectToAction("Index");
        }

        [HttpPost]
        [AdminAuthorize]
        public IActionResult Delete(int id)
        {
            bookService.Delete(id);
            return RedirectToAction("Index");
        }

        [AdminAuthorize]
        public IActionResult Edit(int id)
        {
            var book = bookService.GetBookById(id);
            if (book == null) return NotFound();

            var viewModel = new BookEditViewModel
            {
                Book = new GetBookDto()
                {
                    Id = book.Id,
                    BookName = book.BookName,
                    AuthorName = book.AuthorName,
                    Price = book.Price,
                    PageCount = book.PageCount,
                    img = book.img
                    
                },
                Categories = categoryService.GetCategories()
            };

            return View(viewModel);
        }


    }
}
