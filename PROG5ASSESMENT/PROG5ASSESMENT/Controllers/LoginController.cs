using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PROG5ASSESMENT.Controllers {

    public class LoginController : Controller {

        [HttpGet]
        public ActionResult LogIn() {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(string username, string password) {
            bool check = true;
            if (username != "admin") check = false;
            if (password != "admin") check = false;

            if (check) {
                FormsAuthentication.SetAuthCookie(username, false);
                return RedirectToAction("Index", "Home");
            }
            else {
                return View();
            }
        }

        [HttpGet]
        public ActionResult LogOut() {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}