using AuthenticationFilter_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AuthenticationFilter_MVC.Controllers
{
    public class AccountController : Controller
    {
        Database1Entities db = new Database1Entities();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["username"] = null;
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult Login(Login login, string ReturnUrl)
        {
            if (IsValid(login) == true)
            {
                FormsAuthentication.SetAuthCookie(login.username, false);
                Session["username"] = login.username.ToString();
                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View();
            }
        }
        public bool IsValid(Login login)
        {
            var row = db.Logins.Where(model => model.username == login.username && model.password == login.password).FirstOrDefault();
            if (row != null)
            {
                return (row.username == login.username && row.password == login.password);
            }
            else
            {
                return false;
            }

        }
    }
}