using Microsoft.AspNetCore.Mvc;
using Readify.Domain.Core.Book.Services;

namespace Readify.EndPoint.UI_MVC.Components.Book
{
    public class BookViewComponent(IBookService bookService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var books = bookService.GetRecentlyBooks(5);
            return View("Books", books);
        }
    }
}
