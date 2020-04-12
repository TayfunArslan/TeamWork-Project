using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamWork.Service.Services;
using TeamWork.UI.Attributes;

namespace TeamWork.UI.Controllers
{
    [UserAuthorize]
    public class HomeController : Controller
    {
        IProjectService _projectService;
        public HomeController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}