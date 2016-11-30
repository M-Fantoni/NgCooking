using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NgCooking.Controllers
{
    public class RecipesController : Controller
    {
        // GET: Recipes
        public ActionResult RecipeDetails()
        {
            return View();
        }

        public ActionResult Recipes()
        {
            return View();
        }

        public ActionResult RecipeNew()
        {
            return View();
        }
    }
}