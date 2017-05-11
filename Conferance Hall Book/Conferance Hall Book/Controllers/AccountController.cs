using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Conferance_Hall_Book.Models;

namespace Conferance_Hall_Book.Controllers
{
    public class AccountController : Controller
    {
        private conferencebookingsystemEntities3 db = new conferencebookingsystemEntities3();

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "username,password,designation,sno")] Login login)
        {
            if (ModelState.IsValid)
            {
                db.Logins.Add(login);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(login);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                using (conferencebookingsystemEntities3 db = new conferencebookingsystemEntities3())
                {
                    var obj = db.Logins.Where(a => a.username.Equals(login.username) && a.password.Equals(login.password)).FirstOrDefault();
                    if (obj != null)
                    {
                        return RedirectToAction("AdminIndex", "Home");
                    }
                }
            }
            return View("Login");
        }
    }
}