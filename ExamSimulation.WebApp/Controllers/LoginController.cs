using ExamSimulation.Classes;
using ExamSimulation.Scheduler;
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
            Job newJob = new Job("A job queued at: " + DateTime.Now, DateTime.Now.AddMinutes(4));
            lock (MvcApplication._JobQueue)
            {
                MvcApplication._JobQueue.Add(newJob);
            }
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
                switch (user.IdTypeUser)
                {
                    case TypeUser.Organizzatore:
                        return RedirectToAction("../User");

                    case TypeUser.Invitato:
                        return RedirectToAction("../Activity");

                    case TypeUser.Utente:
                        return RedirectToAction("../Activity");
                }
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