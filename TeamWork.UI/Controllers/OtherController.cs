using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamWork.UI.Attributes;

namespace TeamWork.UI.Controllers
{
    [ExceptionAttribute]
    public class OtherController : Controller
    {
        public ActionResult Error()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View("404");
        }
    }
}