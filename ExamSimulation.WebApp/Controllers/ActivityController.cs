using ExamSimulation.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamSimulation.WebApp.Controllers
{
    public class ActivityController : Controller
    {
        // GET: Activity
        public ActionResult Index()
        {
            DataBase db = new DataBase();
            return View(db.GetActivityForGuest());
        }

        public ActionResult ActivityIndex()
        {
            DataBase db = new DataBase();
            return View(db.GetActivityList());
        }
    }
}