using project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project3.Controllers
{   
    public class RegistrationController : Controller
    {
        // GET: Registration
        [HttpGet]
        public ActionResult Register()
        {
            var r = new register();
            return View(r);
        }
        [HttpPost]
        public ActionResult Register(register r)
        {
            using (sd51Entities dbModel = new sd51Entities())
            {
                dbModel.registers.Add(r);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.successMsg = "Registration successful";
            return View("Register", new register());

        }
        public ActionResult show()
        {
            sd51Entities dbModel = new sd51Entities();
            List<register> data = dbModel.registers.ToList();
            return View(data);
        }
    }
}