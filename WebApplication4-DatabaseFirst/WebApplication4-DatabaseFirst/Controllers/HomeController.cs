using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4_DatabaseFirst.Models;

namespace WebApplication4_DatabaseFirst.Controllers
{
    public class HomeController : Controller
    {
        DatabaseFirstDbEntities db = new DatabaseFirstDbEntities();
        public ActionResult Index(string seachBy, string search)
        {
            if (seachBy == "Name")
            {
                var rows = db.Students.Where(model => model.stdname.Contains(search)).ToList();
                return View(rows);
            }
            else if (seachBy == "Gender")
            {
                var rows = db.Students.Where(model => model.stdgender == search).ToList();
                return View(rows);
            }
            else
            {
                var data = db.Students.ToList();
                return View(data);
            }
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {

            if (ModelState.IsValid == true)
            {
                db.Students.Add(s);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["InsertMessage"] = "Success!";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.InsertMessage = "<script>Error!</script>";
                }
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            var row = db.Students.Where(model => model.stdid == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(Student s)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(s).State = EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["UpdateMessage"] = "Success!";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.UpdateMessage = "<script>Error!</script>";
                }
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var row = db.Students.Where(model => model.stdid == id).FirstOrDefault();
                if (row != null)
                {
                    db.Entry(row).State = EntityState.Deleted;
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        TempData["DeleteeMessage"] = "Success!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.UpdateMessage = "<script>Error!</script>";
                    }
                }

            }
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var row = db.Students.Where(model => model.stdid == id).FirstOrDefault();
            return View(row);
        }
    }
}