using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AJAX_MVC.Models;

namespace AJAX_MVC.Controllers
{
    public class HomeController : Controller
    {
        Database1Entities db = new Database1Entities();
        // GET: Home
        public ActionResult Fetch()
        {
            int number = 5;
            Session["number"] = number;
            var row = db.Employees.ToList().Take(number);
            return View(row);
        }
        [HttpPost]
        public ActionResult Fetch(Employee e)
        {
            var row =Convert.ToInt32(Session["number"])+5;
            var data = db.Employees.ToList().Take(row);
            Session["number"] = row;
            return PartialView("_FetchPartialView", data);
        }
        public ActionResult Main()
        {
            return View(db.Employees.ToList());
        }
        [HttpPost]
        public ActionResult Main(string q)
        {
            if (string.IsNullOrWhiteSpace(q)==false)
            {
                var row = db.Employees.Where(model => model.name.Contains(q)).ToList();
                return PartialView("_SearchPartialView",row);
            }
            else
            {
                var row = db.Employees.ToList();
                return PartialView("_SearchPartialView", row);

            }
        }
        public ActionResult Index()
        { 
            return View();
        }
        [HttpPost]
        public ActionResult Index(Employee e)
        {
            if (ModelState.IsValid==true)
            {
                db.Employees.Add(e);
                int a = db.SaveChanges();
                if (a>0)
                {
                    return JavaScript("alert('Thanks for submiting')");
                }
                else
                {
                    return JavaScript("alert('___ for submiting')");

                }
            }
            return View();
        }

        
    }
}