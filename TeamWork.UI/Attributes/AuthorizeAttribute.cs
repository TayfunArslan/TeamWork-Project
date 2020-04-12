using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamWork.Service.Enum;
using TeamWork.UI.Session;

namespace TeamWork.UI.Attributes
{
    public class UserAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (SessionHelper.ActiveUser != null)
                return true;
            else
            {
                httpContext.Response.Redirect("~/Account/Login");
                return false;
            }

        }
    }

    public class AdminAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (SessionHelper.ActiveUser != null)
            {
                if (SessionHelper.ActiveUser.UserTypeId != (int)UserType.Admin)
                {
                    httpContext.Response.Redirect("~/Home/Index");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                httpContext.Response.Redirect("~/Account/Login");
                return false;
            }

        }
    }
}