using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project3.Models;

namespace project3.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        // GET: orders
        [HttpGet]
        public ActionResult Order()
        {
            var i = new order();
            return View();
        }
        [HttpPost]
        public ActionResult Order(order r)
        {
            using (sd51Entities1 dbModel = new sd51Entities1())
            {
                dbModel.orders.Add(r);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.successMsg = "Added successful";
            return View("Order", new order());

        }
        public ActionResult show()
        {
            List<order> data;
            using (sd51Entities1 dbModel = new sd51Entities1())
            {
                data = dbModel.orders.ToList();


            }


            return View(data);

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            using (sd51Entities1 dbModel = new sd51Entities1())
            {
                return View(dbModel.orders.Where(x => x.orderID == id).FirstOrDefault());


            }




        }
        [HttpPost]
        public ActionResult Edit(int id, order itm)
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
                return View(dbModel.orders.Where(x => x.orderID == id).FirstOrDefault());


            }




        }
        [HttpPost]
        public ActionResult Delete(int id, order itm)
        {
            try
            {

                using (sd51Entities1 dbModel = new sd51Entities1())
                {
                    order i = dbModel.orders.Where(x => x.orderID == id).FirstOrDefault();
                    dbModel.orders.Remove(i);
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