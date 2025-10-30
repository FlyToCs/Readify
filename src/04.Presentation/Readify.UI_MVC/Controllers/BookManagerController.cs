using Microsoft.AspNetCore.Mvc;

namespace Readify.UI_MVC.Controllers
{
    public class BookManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
