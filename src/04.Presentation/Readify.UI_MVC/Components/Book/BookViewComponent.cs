using Microsoft.AspNetCore.Mvc;
using Readify.Domain.BookAgg.Contracts.ServiceContracts;

namespace Readify.UI_MVC.Components.Book
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
