using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamWork.Service.Dto;
using TeamWork.Service.Services;
using TeamWork.UI.Attributes;
using TeamWork.UI.Models;

namespace TeamWork.UI.Controllers
{
    [UserAuthorize]
    public class UserController : Controller
    {
        IUserService _userService;
        IUserTypeService _userTypeService;
        public UserController(IUserService userService,
                                IUserTypeService userTypeService)
        {
            _userService = userService;
            _userTypeService = userTypeService;
        }

        [AdminAuthorize]
        public ActionResult Index()
        {
            UserListModel model = new UserListModel();
            model.Users = _userService.GetAll();

            return View(model);
        }

        [AdminAuthorize]
        public ActionResult AddEdit(string id)
        {
            UserDto model = new UserDto();
            
            if (!string.IsNullOrEmpty(id))
                model = _userService.GetById(Convert.ToInt32(id));

            model.UserTypes = _userTypeService.GetAll();

            return View(model);
        }

        [HttpPost]
        [AdminAuthorize]
        public ActionResult AddEdit(UserDto model)
        {
            if (!ModelState.IsValid)
            {
                model.UserTypes = _userTypeService.GetAll();
                return View(model);
            }


            if (model.Id > 0)
                _userService.Update(model);
            else
                _userService.Add(model);

            return RedirectToAction("Index", "User");
        }
    }
}