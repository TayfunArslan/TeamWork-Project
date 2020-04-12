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
    public class ProjectController : Controller
    {
        IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [AdminAuthorize]
        public ActionResult Index()
        {
            ProjectListModel model = new ProjectListModel();
            model.Projects = _projectService.GetAll();

            return View(model);
        }

        [AdminAuthorize]
        public ActionResult AddEdit(string id)
        {
            ProjectDto model = new ProjectDto();

            if (!string.IsNullOrEmpty(id))
                model = _projectService.GetById(Convert.ToInt32(id));

            return View(model);
        }

        [HttpPost]
        [AdminAuthorize]
        public ActionResult AddEdit(ProjectDto model)
        {
            if (!ModelState.IsValid)
                return View();

            if (model.Id > 0)
                _projectService.Update(model);
            else
                _projectService.Add(model);

            return RedirectToAction("Index", "Project");
        }
    }
}