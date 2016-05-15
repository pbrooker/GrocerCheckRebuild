using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GrocerCheckRebuild.DAL;
using GrocerCheckRebuild.Models;

namespace GrocerCheckRebuild.Controllers
{
    public class GrocerController : Controller
    {
        private GrocerCheckRebuildContext db = new GrocerCheckRebuildContext();

        // GET: Grocer
        public ActionResult Index()
        {
            return View(db.Grocers.ToList());
        }

        // GET: Grocer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grocer grocer = db.Grocers.Find(id);
            if (grocer == null)
            {
                return HttpNotFound();
            }
            return View(grocer);
        }

        // GET: Grocer/Create
        // GET: Brand/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Grocer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // GET: Brand/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "GrocerID,GrocerName")] Grocer grocer)
        {
            if (ModelState.IsValid)
            {
                db.Grocers.Add(grocer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grocer);
        }

        // GET: Grocer/Edit/5
        // GET: Brand/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grocer grocer = db.Grocers.Find(id);
            if (grocer == null)
            {
                return HttpNotFound();
            }
            return View(grocer);
        }

        // POST: Grocer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // GET: Brand/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "GrocerID,GrocerName")] Grocer grocer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grocer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grocer);
        }

        // GET: Grocer/Delete/5
        // GET: Brand/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grocer grocer = db.Grocers.Find(id);
            if (grocer == null)
            {
                return HttpNotFound();
            }
            return View(grocer);
        }

        // POST: Grocer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        // GET: Brand/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Grocer grocer = db.Grocers.Find(id);
            db.Grocers.Remove(grocer);
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
