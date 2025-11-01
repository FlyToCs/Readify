using Microsoft.AspNetCore.Mvc;
using Readify.Domain.UserAgg.Contracts.ServiceContracts;
using Readify.Domain.UserAgg.DTOs;
using Readify.Domain.UserAgg.Enums;
using Readify.UI_MVC.Models;

namespace Readify.UI_MVC.Controllers
{
    public class AccountController(IUserService userService) : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginUserViewModel model)
        {
            var user = userService.Login(model.UserName, model.Password);
            if (user.Data == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else if (user.Data.Role == RoleEnum.Admin)
            {
                return RedirectToAction("Index", "BookManager");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Register(CreateUserDto model)
        {
            userService.Create(model);

            if (model.Role == RoleEnum.Admin)
            {
                return RedirectToAction("Index", "BookManager");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
