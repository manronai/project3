using project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project3.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        [HttpGet]
        public ActionResult add()
        {
            var i = new employee();
            return View(i);
        }
        [HttpPost]
        public ActionResult add(employee r)
        {
            try
            {
                using (sd51Entities1 dbModel = new sd51Entities1())
                {
                    dbModel.employees.Add(r);
                    dbModel.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.successMsg = "Added successful";
                return View("add", new employee());
            }
            catch
            {   
                return View("show");

            }

        }
        public ActionResult show()
        {
            List<employee> data;
            using (sd51Entities1 dbModel = new sd51Entities1())
            {
                data = dbModel.employees.ToList();


            }


            return View(data);

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            using (sd51Entities1 dbModel = new sd51Entities1())
            {
                return View(dbModel.employees.Where(x => x.employeeID == id).FirstOrDefault());


            }




        }
        [HttpPost]
        public ActionResult Edit(int id, employee itm)
        {
            try
            {

                using (sd51Entities1 dbModel = new sd51Entities1())
                {

                    dbModel.Entry(itm).State = System.Data.Entity.EntityState.Modified;
                    dbModel.SaveChanges();
                }


                return RedirectToAction("show");
            }
            catch
            {
                return View();
            }

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {

            using (sd51Entities1 dbModel = new sd51Entities1())
            {
                return View(dbModel.employees.Where(x => x.employeeID == id).FirstOrDefault());


            }




        }
        [HttpPost]
        public ActionResult Delete(int id, employee itm)
        {
            try
            {

                using (sd51Entities1 dbModel = new sd51Entities1())
                {
                    employee i = dbModel.employees.Where(x => x.employeeID == id).FirstOrDefault();
                    dbModel.employees.Remove(i);
                    dbModel.SaveChanges();
                }


                return RedirectToAction("show");
            }
            catch
            {
                return View();
            }

        }
    }
}