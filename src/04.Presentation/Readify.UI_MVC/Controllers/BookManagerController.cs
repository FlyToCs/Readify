using Microsoft.AspNetCore.Mvc;
using Readify.Domain.BookAgg.Contracts.ServiceContracts;
using Readify.Domain.BookAgg.DTOs;
using Readify.Domain.CategoryAgg.Contracts.ServiceContracts;
using Readify.Infrastructure.Repository;
using Readify.UI_MVC.Models;
using System.Runtime.InteropServices.JavaScript;
using Readify.UI_MVC.Database;

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
            if (InMemoryDatabase.OnlineUser != null)
            {
                createBook.UserId = InMemoryDatabase.OnlineUser.Id;
                bookService.Create(createBook);
                return RedirectToAction("Index");
            }
            return RedirectToAction("UnAuthorization", "Account");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            bookService.Delete(id);
            return RedirectToAction("Index");
        }

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
