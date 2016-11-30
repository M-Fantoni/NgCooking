using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NgCooking.Utils
{
    public static class CookiesManagement
    {
        public static bool CreateCookie(int User, ControllerContext controller)
        {
            try
            {
                HttpCookie cookie = new HttpCookie("NgUser");
                cookie.Value = User.ToString();

                controller.HttpContext.Response.Cookies.Add(cookie);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public static bool DeleteCookie(ControllerContext controller)
        {
            HttpCookie cookie = controller.HttpContext.Request.Cookies["NgUser"];
            cookie.Expires = DateTime.Now.AddDays(-1);
            controller.HttpContext.Response.Cookies.Add(cookie);

            return true;
        }

        public static int ReadCookie(ControllerContext controller)
        {
            int User = -1;

            if (controller.HttpContext.Request.Cookies.AllKeys.Contains("NgUser"))
            {
                int parsedUser; 
                int.TryParse(controller.HttpContext.Request.Cookies["NgUser"].Value, out parsedUser);

                User = parsedUser;

                return User;
            }
            else
            {
                return User;
            }
        }

    }
}