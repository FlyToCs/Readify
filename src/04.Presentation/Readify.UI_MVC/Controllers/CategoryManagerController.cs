using Microsoft.AspNetCore.Mvc;

namespace Readify.UI_MVC.Controllers
{
    public class CategoryManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
