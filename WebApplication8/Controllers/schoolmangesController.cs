using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class schoolmangesController : Controller
    {
        private schoolEntities db = new schoolEntities();

        // GET: schoolmanges
        public ActionResult Index()
        {
            return View(db.schoolmanges.ToList());
        }

        // GET: schoolmanges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            schoolmange schoolmange = db.schoolmanges.Find(id);
            if (schoolmange == null)
            {
                return HttpNotFound();
            }
            return View(schoolmange);
        }

        // GET: schoolmanges/Create
        public ActionResult Create()
        {
            return View(new schoolmange());
        }

        // POST: schoolmanges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,StuName,Class,Subject")] schoolmange schoolmange)
        {
            if (ModelState.IsValid)
            {
                db.schoolmanges.Add(schoolmange);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(schoolmange);
        }

        // GET: schoolmanges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            schoolmange schoolmange = db.schoolmanges.Find(id);
            if (schoolmange == null)
            {
                return HttpNotFound();
            }
            return View(schoolmange);
        }

        // POST: schoolmanges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,StuName,Class,Subject")] schoolmange schoolmange)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schoolmange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(schoolmange);
        }

        // GET: schoolmanges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            schoolmange schoolmange = db.schoolmanges.Find(id);
            if (schoolmange == null)
            {
                return HttpNotFound();
            }
            return View(schoolmange);
        }

        // POST: schoolmanges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            schoolmange schoolmange = db.schoolmanges.Find(id);
            db.schoolmanges.Remove(schoolmange);
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
