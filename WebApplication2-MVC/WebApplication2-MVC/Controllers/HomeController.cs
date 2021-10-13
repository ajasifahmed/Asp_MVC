using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2_MVC.Models;

namespace WebApplication2_MVC.Controllers
{
    public class HomeController : Controller
    {
        List<Product> Products = new List<Product>()
        {
            new Product {ID=1,Name="Nike",image="~/images/i1.png" },
            new Product {ID=2,Name="Ekin",image="~/images/i2.jpg" },
            new Product {ID=3,Name="Kine",image="~/images/i3.jpg" },
            new Product {ID=4,Name="Inike",image="~/images/i4.jpg" }
        };
        // GET: Home
        public ActionResult Index()
        {
            return View(Products);
        }


    }
}