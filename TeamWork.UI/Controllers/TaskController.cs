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
    [ExceptionAttribute]
    public class TaskController : Controller
    {
        ITaskService _taskService;
        IProjectService _projectService;
        ITaskStatusService _taskStatusService;
        IUserService _userService;
        public TaskController(ITaskService taskService,
                                IProjectService projectService,
                                ITaskStatusService taskStatusService,
                                IUserService userService)
        {
            _taskService = taskService;
            _projectService = projectService;
            _taskStatusService = taskStatusService;
            _userService = userService;
        }

        public ActionResult Index()
        {
            TaskListModel model = new TaskListModel();
            model.Tasks = _taskService.GetAll();

            model.Projects = _projectService.GetAll();
            model.TasStatuses = _taskStatusService.GetAll();
            model.Users = _userService.GetAll();

            return View(model);
        }

        public ActionResult Search(TaskSearchModel searchModel)
        {
            TaskListModel model = new TaskListModel();
            model.Tasks = _taskService.Search(new TaskSearchDto
            {
                ProjectId = searchModel.ProjectId,
                TaskStatusId = searchModel.TaskStatusId,
                UserId = searchModel.UserId
            });

            return PartialView("_List", model);
        }
    }
}