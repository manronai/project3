using project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project3.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult login()
        {
            Session.Remove("userID");
            Session.Remove("userName");
            Session.Abandon();

            return View();
        }
        
        [HttpPost]
        public ActionResult Autherize(register userModel)
        {
            using (sd51Entities db = new sd51Entities())
            {
                var userDetails = db.registers.Where(x => x.username == userModel.username && x.password == userModel.password).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.LoginErrorMessage = "Wrong username or password.";
                    return View("Index", userModel);
                }
                else
                {
                    userModel.LoginErrorMessage = "Wrong username or password.";
                    Session["userID"] = userDetails.userid;
                    Session["userName"] = userDetails.username;
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        public ActionResult logout()
        {
            int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("login", "Login");
        }

    }
}