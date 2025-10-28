using Microsoft.AspNetCore.Mvc;
using Readify.Domain.BookAgg.Contracts.ServiceContracts;
using Readify.Domain.BookAgg.DTOs;
using Readify.Infrastructure.Persistence;
using Readify.Infrastructure.Repository;
using Readify.Services;
using Readify.UI_MVC.Models;
using System.Diagnostics;
using Readify.Domain.CategoryAgg.Contracts.ServiceContracts;

namespace Readify.UI_MVC.Controllers
{
    public class HomeController(
        ILogger<HomeController> logger,
        IBookService bookService,
        ICategoryService categoryService)
        : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;



        public IActionResult Index()
        {

            CategoryBookViewModel model = new CategoryBookViewModel()
            {
                Books = bookService.GetRecentlyBooks(5),
                Categories = categoryService.GetPopularCategories(5)
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
