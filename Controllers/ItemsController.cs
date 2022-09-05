using project3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project3.Controllers
{
    public class ItemsController : Controller
    {
        // GET: Items
        [HttpGet]
        public ActionResult add()
        {
            var i = new item();
            return View();
        }
        [HttpPost]
        public ActionResult add(item r)
        {
            using (sd51Entities dbModel = new sd51Entities())
            {
                dbModel.items.Add(r);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.successMsg = "Added successful";
            return View("add", new item());

        }
        public ActionResult show()
        {
            List<item> data;
            using (sd51Entities dbModel = new sd51Entities())
            {
                data = dbModel.items.ToList();

                
            }
           
            
            return View(data);

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            
            using (sd51Entities dbModel = new sd51Entities())
            {
                return View(dbModel.items.Where(x => x.itemID == id).FirstOrDefault());


            }


            

        }
        [HttpPost]
        public ActionResult Edit(int id, item itm)
        {
            try {

                using (sd51Entities dbModel = new sd51Entities())
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

            using (sd51Entities dbModel = new sd51Entities())
            {
                return View(dbModel.items.Where(x => x.itemID == id).FirstOrDefault());


            }




        }
        [HttpPost]
        public ActionResult Delete(int id, item itm)
        {
            try
            {

                using (sd51Entities dbModel = new sd51Entities())
                {
                    item i = dbModel.items.Where(x => x.itemID == id).FirstOrDefault();
                    dbModel.items.Remove(i);
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