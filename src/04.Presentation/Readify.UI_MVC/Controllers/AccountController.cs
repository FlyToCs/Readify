using Microsoft.AspNetCore.Mvc;
using Readify.Domain.UserAgg.Contracts.ServiceContracts;
using Readify.Domain.UserAgg.DTOs;
using Readify.Domain.UserAgg.Enums;
using Readify.UI_MVC.Database;
using Readify.UI_MVC.Models;

namespace Readify.UI_MVC.Controllers
{
    public class AccountController(IUserService userService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginUserViewModel model)
        {
            var result = userService.Login(model.UserName, model.Password);

            if (result.Data != null)
            {
                InMemoryDatabase.OnlineUser = new OnlineUser()
                {
                    Username = result.Data.UserName,
                    Id = result.Data.Id,
                    IsActive = result.Data.IsActive,
                    Role = result.Data.Role
                };
                if (result.Data.Role == RoleEnum.Admin)
                    return RedirectToAction("Index", "Account");
            }

            if (!result.IsSuccess)
            {
                ViewBag.Error = result.Message; 
                return View(model); 
            }

            return RedirectToAction("Index", "Home");
        }



        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register(CreateUserDto model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = userService.Create(model);

            if (!result.IsSuccess)
            {
                ViewBag.Error = result.Message;
                return View(model);
            }

            if (model.Role == RoleEnum.Admin)
                return RedirectToAction("Index", "BookManager");

            return RedirectToAction("Index", "Home");
        }


    }
}
