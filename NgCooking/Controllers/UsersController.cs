using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NgCooking.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult UserDetails()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }
    }
}