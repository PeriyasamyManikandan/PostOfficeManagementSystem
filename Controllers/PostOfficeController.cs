
using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using PostOfficeManagementSystem.Models;

namespace PostOfficeManagementSystem.Controllers
{
    public class PostOfficeController : Controller
    {
        private PostOfficeDBEntities db = new PostOfficeDBEntities();

        public ActionResult Index()
        {
            try
            {
                var records = db.Postoffices.ToList();
                return View(records);
            }
            catch (Exception)
            {
                TempData["Error"] =
                    "An error occurred while retrieving Post Office records.";

                return View(new List<Postoffice>());
            }
            finally
            {
                // Executes whether an exception occurs or not.
            }
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Postoffice model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Postoffices.Add(model);
                    db.SaveChanges();

                    TempData["Success"] = "Record created successfully!";
                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception)
            {
                ModelState.AddModelError("",
                    "An error occurred while saving the record.");

                return View(model);
            }
            finally
            {
                // Executes whether an exception occurs or not.
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                var record = db.Postoffices.Find(id);

                if (record == null)
                {
                    return HttpNotFound();
                }

                return View(record);
            }
            catch (Exception)
            {
                TempData["Error"] = "Unable to retrieve the record.";
                return RedirectToAction("Index");
            }
            finally
            {
                // Executes whether an exception occurs or not.
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Postoffice model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(model).State =
                        System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();

                    TempData["Success"] = "Record updated successfully!";
                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception)
            {
                ModelState.AddModelError("",
                    "An error occurred while updating the record.");

                return View(model);
            }
            finally
            {
                // Executes whether an exception occurs or not.
            }
        }

        //[HttpGet]
        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
        //        var record = db.Postoffices.Find(id);

        //        if (record == null)
        //        {
        //            return HttpNotFound();
        //        }

        //        return View(record);
        //    }
        //    catch (Exception)
        //    {
        //        TempData["Error"] = "Unable to retrieve the record.";
        //        return RedirectToAction("Index");
        //    }
        //    finally
        //    {
        //        // Executes whether an exception occurs or not.
        //    }
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, FormCollection form)
        //{
        //    try
        //    {
        //        var record = db.Postoffices.Find(id);

        //        if (record == null)
        //        {
        //            TempData["Error"] = "Record not found.";
        //            return RedirectToAction("Index");
        //        }

        //        db.Postoffices.Remove(record);
        //        db.SaveChanges();

        //        TempData["Success"] = "Record deleted successfully!";
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception)
        //    {
        //        TempData["Error"] = "An error occurred while deleting the record.";
        //        return RedirectToAction("Index");
        //    }
        //    finally
        //    {
        //        // Executes whether an exception occurs or not.
        //    }
        //}
public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["Error"] = "Invalid record ID.";
                    return RedirectToAction("Index");
                }

                var record = db.Postoffices.Find(id);

                if (record == null)
                {
                    TempData["Error"] = "Record not found.";
                    return RedirectToAction("Index");
                }

                return View(record);
            }
            catch (Exception)
            {
                TempData["Error"] = "Error retrieving the record.";
                return RedirectToAction("Index");
            }
            finally
            {
                // Executes whether an exception occurs or not.
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var record = db.Postoffices.Find(id);

                if (record == null)
                {
                    TempData["Error"] = "Record not found.";
                    return RedirectToAction("Index");
                }

                db.Postoffices.Remove(record);
                db.SaveChanges();

                TempData["Success"] = "Record deleted successfully!";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["Error"] = "An error occurred while deleting the record.";
                return RedirectToAction("Index");
            }
            finally
            {
                // Executes whether an exception occurs or not.
            }
        }

        public ActionResult Details(int id)
        {
            try
            {
                var record = db.Postoffices.Find(id);

                if (record == null)
                {
                    return HttpNotFound();
                }

                return View(record);
            }
            catch (Exception)
            {
                TempData["Error"] =
                    "An error occurred while retrieving the record.";

                return RedirectToAction("Index");
            }
            finally
            {
                // Executes whether an exception occurs or not.
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}