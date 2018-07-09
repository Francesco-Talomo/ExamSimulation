using ExamSimulation.Classes;
using System;
using System.Collections.Generic;
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

        // GET: Activity/Details/5
        public ActionResult Details(int id)
        {
            if (Session["TypeUser"] != null && Session["TypeUser"].ToString().Equals(TypeUser.Organizzatore.ToString()))
            {
                DataBase db = new DataBase();
                return View(db.GetActivityList().Find(model => model.Id == id));
            }
            return RedirectToAction("../Login");
        }

        // GET: Activity/Create
        public ActionResult Create()
        {
            if (Session["TypeUser"] != null && Session["TypeUser"].ToString().Equals(TypeUser.Organizzatore.ToString()))
            {
                return View();
            }
            return RedirectToAction("../Login");
        }

        // POST: Activity/Create
        [HttpPost]
        public ActionResult Create(Activity activity)
        {
            if (Session["TypeUser"] != null && Session["TypeUser"].ToString().Equals(TypeUser.Organizzatore.ToString()))
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        DataBase db = new DataBase();
                        if (db.InsertActivity(activity))
                        {
                            ViewBag.Message = "User Details Added Successfully";
                            ModelState.Clear();
                        }
                    }
                    return View();
                }
                catch
                {
                    return View();
                }
            }
            return RedirectToAction("../Login");
        }

        // GET: Activity/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["TypeUser"] != null && Session["TypeUser"].ToString().Equals(TypeUser.Organizzatore.ToString()))
            {
                DataBase db = new DataBase();
                return View(db.GetActivityList().Find(model => model.Id == id));
            }
            return RedirectToAction("../Login");
        }

        // POST: Activity/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Activity activity)
        {
            if (Session["TypeUser"] != null && Session["TypeUser"].ToString().Equals(TypeUser.Organizzatore.ToString()))
            {
                try
                {
                    DataBase db = new DataBase();
                    db.UpdateActivity(activity);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return RedirectToAction("../Login");
        }

        // GET: Activity/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["TypeUser"] != null && Session["TypeUser"].ToString().Equals(TypeUser.Organizzatore.ToString()))
            {
                DataBase db = new DataBase();
                return View(db.GetActivityList().Find(model => model.Id == id));
            }
            return RedirectToAction("../Login");
        }

        // POST: Activity/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Activity activity)
        {
            if (Session["TypeUser"] != null && Session["TypeUser"].ToString().Equals(TypeUser.Organizzatore.ToString()))
            {
                try
                {
                    DataBase db = new DataBase();
                    activity = db.GetActivityList().Find(model => model.Id == id);
                    if (db.DeleteActivity(id, activity))
                    {
                        ViewBag.AlertMsg = "Student Deleted Successfully";
                    }
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return RedirectToAction("../Login");
        }
    }
}