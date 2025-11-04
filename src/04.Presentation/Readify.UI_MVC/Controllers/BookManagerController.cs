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
    [AdminAuthorize]
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
                createBook.UserId = HttpContext.Session.GetInt32("UserId")!.Value; 
                bookService.Create(createBook);
                return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            bookService.Delete(id);
            return RedirectToAction("Index");
        }


        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = bookService.GetBookById(id);
            if (book == null)
                return NotFound();

            var viewModel = new BookEditViewModel
            {
                Book = new UpdateBookDto
                {
                    BookId = book.Id,
                    CategoryId = book.CategoryId,
                    ImgUrl = book.img?.ImageUrl, 
                    BookName = book.BookName,
                    Price = book.Price,
                    AuthorName = book.AuthorName,
                    PageCount = book.PageCount,
                    UserId = HttpContext.Session.GetInt32("UserId")!.Value
                },
                Categories = categoryService.GetCategories()
            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Edit(int id, BookEditViewModel model)
        {


            var result = bookService.Update(id, model.Book);

            if (!result.IsSuccess)
            {
                ViewBag.Error = result.Message;
                model.Categories = categoryService.GetCategories(); 
                return View(model);
            }

            ViewBag.Error = result.Message;
            return RedirectToAction("Index");
        }



    }
}
