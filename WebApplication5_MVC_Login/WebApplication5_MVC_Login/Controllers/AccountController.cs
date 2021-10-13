using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication5_MVC_Login.Models;

namespace WebApplication5_MVC_Login.Controllers
{
    public class AccountController : Controller
    {
        Entities1 db = new Entities1();
        // GET: Account
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(Signup s)
        {
            if (ModelState.IsValid == true)
            {
                db.Signups.Add(s);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    ModelState.Clear();
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        public ActionResult Login()
        {
            HttpCookie cookie = Request.Cookies["username"];
            if (cookie != null)
            {
                ViewBag.username = cookie["user"].ToString();
                //DECRYPT PASSWORD
                string EncPwd = cookie["password"].ToString();
                byte[] b = Convert.FromBase64String(EncPwd);
                string DecPwd = Encoding.ASCII.GetString(b);
                ViewBag.password = DecPwd.ToString();
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(Signup s)
        {
            HttpCookie cookie = new HttpCookie("username");
                if (s.RemembeMe == true)
                {
                    cookie["user"] = s.email;
                    //ECODING PASSWORD
                    byte[] b = Encoding.ASCII.GetBytes(s.password);
                    string EncPwd = Convert.ToBase64String(b);
                    cookie["password"] = EncPwd;
                    //
                    cookie.Expires = DateTime.Now.AddDays(1);
                    HttpContext.Response.Cookies.Add(cookie);
                }
                else
                {
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Response.Cookies.Add(cookie);

                }
                var row = db.Signups.Where(model => model.email == s.email && model.password == s.password).FirstOrDefault();
                if (row != null)
                {

                    Session["username"] =row.name.ToString();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Error"] = "<script>alert('Error!')</script>";
                    return View();
                }

        }
        //public ActionResult Reset()
        //{
        //    ModelState.Clear();
        //    return RedirectToAction("Login");
        //}
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }

    }
}