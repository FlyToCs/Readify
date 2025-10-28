using Microsoft.AspNetCore.Mvc;
using Readify.Domain.BookAgg.Contracts.ServiceContracts;
using Readify.Domain.BookAgg.DTOs;
using Readify.Infrastructure.Persistence;
using Readify.Infrastructure.Repository;
using Readify.Services;
using Readify.UI_MVC.Models;
using System.Diagnostics;

namespace Readify.UI_MVC.Controllers
{
    public class HomeController(
        ILogger<HomeController> logger,
        IBookService bookService,
        ICategoryService categoryService)
        : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly IBookService _bookService = bookService;
        private readonly ICategoryService _categoryService = categoryService;


        public IActionResult Index()
        {

            CategoryBookViewModel model = new CategoryBookViewModel()
            {
                Books = _bookService.GetRecentlyBooks(5),
                Categories = _categoryService.GetPopularCategories(5)
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
