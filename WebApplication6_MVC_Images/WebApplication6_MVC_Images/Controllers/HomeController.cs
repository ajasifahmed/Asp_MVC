using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6_MVC_Images.Models;
using System.IO;
using System.Data.Entity;

namespace WebApplication6_MVC_Images.Controllers
{
    public class HomeController : Controller
    {
        DatabaseFirstDbEntities db = new DatabaseFirstDbEntities();
        public ActionResult Index()
        {
            var data = db.Student2.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student2 s)
        {
            string fileName = Path.GetFileNameWithoutExtension(s.ImageFile.FileName);
            string extension = Path.GetExtension(s.ImageFile.FileName);
            fileName = fileName + extension;
            s.img_path = "~/Images/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
            s.ImageFile.SaveAs(fileName);
            db.Student2.Add(s);
            int a = db.SaveChanges();
            if (a > 0)
            {
                ModelState.Clear();
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            var row = db.Student2.Where(model => model.Id == id).FirstOrDefault();
            Session["image_path"] = row.img_path;
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(Student2 s)
        {
            if (s.ImageFile != null)
            {
                
                string fileName = Path.GetFileNameWithoutExtension(s.ImageFile.FileName);
                string extension = Path.GetExtension(s.ImageFile.FileName);
                fileName = fileName + extension;
                s.img_path = "~/Images/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                s.ImageFile.SaveAs(fileName);
                db.Entry(s).State = EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    string ImagePath=Request.MapPath(Session["image_path"].ToString());
                    if (System.IO.File.Exists(ImagePath))
                    {
                        System.IO.File.Delete(ImagePath);
                    }
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                s.img_path = Session["image_path"].ToString();
                db.Entry(s).State = EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

    }
}