using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NgCooking.Controllers
{
    public class IngredientsController : Controller
    {
        // GET: Ingredients
        public ActionResult Ingredients()
        {
            return View();
        }
    }
}