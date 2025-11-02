using Microsoft.AspNetCore.Mvc;
using Readify.Domain.UserAgg.Contracts.ServiceContracts;

namespace Readify.UI_MVC.Controllers
{
    public class UserController(IUserService userService) : Controller
    {
        public IActionResult Index()
        {
            var users = userService.GetAll();
            return View(users.Data);
        }


    }
}
