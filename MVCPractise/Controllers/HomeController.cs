using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCPractise;

namespace MVCPractise.Controllers
{
    public class HomeController : Controller
    {
        private employeeEntities db = new employeeEntities();

        public ActionResult Index()
        {
            return View(db.edetails.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            edetail edetail = db.edetails.Find(id);
            if (edetail == null)
            {
                return HttpNotFound();
            }
            return View(edetail);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Gender,City")] edetail edetail)
        {
            if (ModelState.IsValid)
            {
                db.edetails.Add(edetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(edetail);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            edetail edetail = db.edetails.Find(id);
            if (edetail == null)
            {
                return HttpNotFound();
            }
            return View(edetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Gender,City")] edetail edetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(edetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(edetail);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            edetail edetail = db.edetails.Find(id);
            if (edetail == null)
            {
                return HttpNotFound();
            }
            return View(edetail);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            edetail edetail = db.edetails.Find(id);
            db.edetails.Remove(edetail);
            db.SaveChanges();
            return RedirectToAction("Index");
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
