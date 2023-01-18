using System;
using System.Linq;
using System.Threading.Tasks;
using InternetShop.Domain.ViewModels.User;
using InternetShop.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InternetShop.Domain.Response;

namespace InternetShop.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /*Вывести всех зарегестрированых пользователей*/
        public async Task<IActionResult> GetUsers()
        {
            var response = await _userService.GetUsers();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Index", "Home");
        }

        /*Удалить пользователя*/
        public async Task<IActionResult> DeleteUser(long id,string userName)
        {
            var response = await _userService.DeleteUser(id,User.Identity.Name);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetUsers");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}