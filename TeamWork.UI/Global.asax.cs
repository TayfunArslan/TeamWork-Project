using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TeamWork.Service.Services;
using TeamWork.UI;
using TeamWork.UI.Helper;
using Unity;
using Unity.AspNet.Mvc;

namespace TeamWork.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            IoCConfig();
        }

        private void IoCConfig()
        {
            UnityContainer container = new UnityContainer();

            container.RegisterType<IProjectService, ProjectService>();
            container.RegisterType<ITaskHistoryService, TaskHistoryService>();
            container.RegisterType<ITaskService, TaskService>();
            container.RegisterType<ITaskStatusService, TaskStatusService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IUserTypeService, UserTypeService>();

            IoCManager.Container = container;
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
