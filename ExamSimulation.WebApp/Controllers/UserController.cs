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
            DataBase db = new DataBase();
            ModelState.Clear();
            return View(db.GetAllUserInListUser());
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            DataBase db = new DataBase();
            return View(db.GetAllUserInListUser().Find(smodel => smodel.Id == id));
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
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

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            DataBase db = new DataBase();
            return View(db.GetAllUserInListUser().Find(smodel => smodel.Id == id));
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            DataBase db = new DataBase();
            return View(db.GetAllUserInListUser().Find(smodel => smodel.Id == id));
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, User user)
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
    }
}