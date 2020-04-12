using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamWork.Service.Dto;

namespace TeamWork.UI.Session
{
    public static class SessionHelper
    {
        public static UserDto ActiveUser
        {
            get
            {
                if (HttpContext.Current.Session["ActiveUser"] != null)
                    return (UserDto)HttpContext.Current.Session["ActiveUser"];
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Session["ActiveUser"] = value;
            }
        }
    }
}