using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1_MVC.Models;
namespace WebApplication1_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            string[] Fruits = { "a", "b", "c", "d", "e", "f" };
            ViewData["Fruits"] = Fruits;

            Employee Asad = new Employee()
            {
                ID = 1, Age = 33, PIN = 1100
            };
            ViewData["Asad"] = Asad;
            Employee Akbar = new Employee()
            {
                ID = 2,
                Age = 13,
                PIN = 100
            };
            Employee Akmal = new Employee()
            {
                ID = 3,
                Age = 33,
                PIN = 110
            };

            ViewData["Akbar"] = Akbar;

            List<Employee> employees = new List<Employee>();
            employees.Add(Asad);employees.Add(Akbar);employees.Add(Akmal);
            return View(employees);
        }
        public ActionResult About()
        {
            return View();
        }
    }
}