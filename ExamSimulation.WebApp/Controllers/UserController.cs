using ExamSimulation.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamSimulation.WebApp.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            if (Session["TypeUser"] != null && Session["TypeUser"].ToString().Equals(TypeUser.Organizzatore.ToString()))
            {
                DataBase db = new DataBase();
                ModelState.Clear();
                return View(db.GetAllUserInListUser());
            }
            return RedirectToAction("../Login");
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            if (Session["TypeUser"] != null && Session["TypeUser"].ToString().Equals(TypeUser.Organizzatore.ToString()))
            {
                DataBase db = new DataBase();
                return View(db.GetAllUserInListUser().Find(model => model.Id == id));
            }
            return RedirectToAction("../Login");
        }

        // GET: User/Create
        public ActionResult Create()
        {
            if (Session["TypeUser"] != null && Session["TypeUser"].ToString().Equals(TypeUser.Organizzatore.ToString()))
            {
                return View();
            }
            return RedirectToAction("../Login");
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (Session["TypeUser"] != null && Session["TypeUser"].ToString().Equals(TypeUser.Organizzatore.ToString()))
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        DataBase db = new DataBase();
                        if (db.InsertUser(user))
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

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["TypeUser"] != null && Session["TypeUser"].ToString().Equals(TypeUser.Organizzatore.ToString()))
            {
                DataBase db = new DataBase();
                return View(db.GetAllUserInListUser().Find(model => model.Id == id));
            }
            return RedirectToAction("../Login");
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            if (Session["TypeUser"] != null && Session["TypeUser"].ToString().Equals(TypeUser.Organizzatore.ToString()))
            {
                try
                {
                    DataBase db = new DataBase();
                    db.UpdateUser(user);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return RedirectToAction("../Login");
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["TypeUser"] != null && Session["TypeUser"].ToString().Equals(TypeUser.Organizzatore.ToString()))
            {
                DataBase db = new DataBase();
                return View(db.GetAllUserInListUser().Find(model => model.Id == id));
            }
            return RedirectToAction("../Login");
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, User user)
        {
            if (Session["TypeUser"] != null && Session["TypeUser"].ToString().Equals(TypeUser.Organizzatore.ToString()))
            {
                try
                {
                    DataBase db = new DataBase();
                    if (db.DeleteUser(id))
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