using NgCooking.Models;
using NgData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NgCooking.Controllers
{
    public class ConnexionController : Controller
    {
        Context context = new Context();
        // GET: Connexion
        [HttpPost]
        public ActionResult Connect(ConnexionModel model)
        {
            NgData.Models.User user = context.Users.SingleOrDefault(m => m.Email == model.Login && m.Password == model.Password);

            if (user != null)
            {
                Utils.CookiesManagement.CreateCookie(user.Id, this.ControllerContext);

                return JavaScript("location.reload(true)");
            }
            else
            {
                string message = "Wrong Login or Password";

                return Json(message);
            }

        }

        public ActionResult Disconnect()
        {
            Utils.CookiesManagement.DeleteCookie(this.ControllerContext);

            return RedirectToAction("Index", "Home");
        }
    }
}