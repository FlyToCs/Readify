using Microsoft.AspNetCore.Mvc;
using Readify.Domain.UserAgg.Contracts.ServiceContracts;
using Readify.Domain.UserAgg.DTOs;
using Readify.Domain.UserAgg.Enums;

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
            if (!ModelState.IsValid)
            {
                ViewBag.Error = "Please enter valid data.";
                return View(model);
            }

            var result = userService.Login(model.UserName, model.Password);

            if (!result.IsSuccess || result.Data == null)
            {
                ViewBag.Error = result.Message ?? "Invalid username or password.";
                return View(model);
            }

            HttpContext.Session.SetInt32("UserId", result.Data.Id);
            HttpContext.Session.SetString("Username", result.Data.UserName);
            HttpContext.Session.SetString("Role", result.Data.Role.ToString());
            HttpContext.Session.SetString("IsActive", result.Data.IsActive.ToString());

            if (result.Data.Role == RoleEnum.Admin)
                return RedirectToAction("Index", "BookManager");

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

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}
