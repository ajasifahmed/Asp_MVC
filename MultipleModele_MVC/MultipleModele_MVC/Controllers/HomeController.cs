using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MultipleModele_MVC.Models;
namespace MultipleModele_MVC.Controllers
{
    public class HomeController : Controller
    {
        Database1Entities db = new Database1Entities();
        // GET: Home
        public ActionResult Index()
        {
            var p1 = Getp1();
            var p2=Getp();
            //using class
            //MultipleModels data = new MultipleModels();
            //data.MyPerson = p1;
            //data.MyPerson2 = p2;
            //return View(data);
            ViewBag.p1 = p1;
            ViewBag.p2 = p2;
            return View();
        }
        public List<Person> Getp1()
        {
            return db.People.ToList();
        }
        public List<Perosn2> Getp()
        {
            return db.Perosn2.ToList();

        }
    }

}