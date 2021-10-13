using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JqueryDatatable_MVC.Models;

namespace JqueryDatatable_MVC.Controllers
{
   
    public class HomeController : Controller
    {
        Database1Entities db = new Database1Entities();
        // GET: Home
        public ActionResult Index()
        {

            return View(db.Tables.ToList());
        }
    }
}