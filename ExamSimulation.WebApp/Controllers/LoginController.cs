using ExamSimulation.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamSimulation.WebApp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login login)
        {
            DataBase db = new DataBase();
            User user = db.GetUserFromLogin(login);
            if (user.IdTypeUser != 0)
            {
                Session["TypeUser"] = user.IdTypeUser.ToString();
                return RedirectToAction("../User");
            }
            else
            {
                ViewData["Message"] = "User Login Details Failed !";
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("../Login");
        }
    }
}