using Microsoft.AspNetCore.Mvc;
using Readify.Domain.UserAgg.Contracts.ServiceContracts;
using Readify.UI_MVC.CustomAttribute;

namespace Readify.UI_MVC.Controllers
{
    public class UserController(IUserService userService) : Controller
    {

        [AdminAuthorize]
        public IActionResult Index()
        {
            var users = userService.GetAll();
            return View(users.Data);
        }


    }
}
