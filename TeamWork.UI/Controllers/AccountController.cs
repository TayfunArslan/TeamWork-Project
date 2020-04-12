using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamWork.Service.Dto;
using TeamWork.Service.Services;
using TeamWork.UI.Session;

namespace TeamWork.UI.Controllers
{
    public class AccountController : Controller
    {
        IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Login(UserDto model, string returnUrl)
        {
            if (string.IsNullOrEmpty(model.Username) && string.IsNullOrEmpty(model.Password))
            {
                return View(model);
            }

            UserDto user = _userService.Login(model.Username, model.Password);
            if (user != null && user.Id > 0)
            {
                SessionHelper.ActiveUser = user;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //Hata var ise gösterilecek
                ViewData["Message"] = "Kullanıcı adı ya da şifre hatalı!";
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }
    }
}