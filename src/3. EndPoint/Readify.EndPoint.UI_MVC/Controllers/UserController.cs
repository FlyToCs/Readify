using Microsoft.AspNetCore.Mvc;
using Readify.Domain.Core.User.AppServices;
using Readify.Domain.Core.User.DTOs;
using Readify.EndPoint.UI_MVC.CustomAttribute;

namespace Readify.EndPoint.UI_MVC.Controllers
{
    [AdminAuthorize]
    public class UserController(IUserService userService) : Controller
    {

        public IActionResult Index()
        {
            var users = userService.GetAll();
            return View(users.Data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateUserDto model)
        {
            var result = userService.Create(model);

            if (!result.IsSuccess)
            {
                ViewBag.Error = result.Message;
                return View();
            }

            return RedirectToAction("Index", "User");

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            userService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ChangeStatus(int id)
        {
            var user = userService.GetById(id);

            if (user == null)
                return NotFound();

            bool newStatus = !user.Data.IsActive;
            userService.UpdateStatus(id, newStatus);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = userService.GetById(id);
            if (!user.IsSuccess || user.Data == null)
            {
                ViewBag.Error = user.Message;
                return View();
            }


            var model = new EditUserDto()
            {
                Id = user.Data.Id,
                FirstName = user.Data.FirstName,
                LastName = user.Data.LastName,
                UserName = user.Data.UserName,
                ImgUrl = user.Data.ImgUrl,
                Role = user.Data.Role
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(EditUserDto model)
        {


            var dto = new CreateUserDto()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Password = model.Password,
                ImgFile = model.ImgFile,
                ImgUrl = model.ImgUrl,
                Role = model.Role
            };

            var result = userService.Update(model.Id, dto);

            if (!result.IsSuccess)
            {
                ViewBag.Error = result.Message;
                return View(model);
            }

            return RedirectToAction("Index");
        }




    }
}
