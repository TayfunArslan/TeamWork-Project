using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeamWork.UI.Attributes
{
    public class ExceptionAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            //Burada hataları loglama işlemleri de yapılabilir!

            base.OnException(filterContext);

            filterContext.HttpContext.Session["Error"] = filterContext.Exception;
            filterContext.HttpContext.Response.Redirect("~/Other/Error");
        }
    }
}