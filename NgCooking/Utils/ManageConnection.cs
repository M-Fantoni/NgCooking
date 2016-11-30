using NgData;
using NgData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NgCooking.Utils
{
    public static class ManageConnection
    {
        public static bool isConnected(ControllerContext controller, Context context)
        {
            int id = Utils.CookiesManagement.ReadCookie(controller);

            User user = context.Users.SingleOrDefault(m => m.Id == id);

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}