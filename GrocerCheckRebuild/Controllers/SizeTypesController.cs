﻿using System;
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
    public class SizeTypesController : Controller
    {
        private GrocerCheckRebuildContext db = new GrocerCheckRebuildContext();

        // GET: SizeTypes
        public ActionResult Index()
        {
            return View(db.SizeTypes.ToList());
        }

        // GET: SizeTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SizeType sizeType = db.SizeTypes.Find(id);
            if (sizeType == null)
            {
                return HttpNotFound();
            }
            return View(sizeType);
        }

        // GET: SizeTypes/Create
        // GET: Brand/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: SizeTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // GET: Brand/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "SizeTypeID,SizeTypeName")] SizeType sizeType)
        {
            if (ModelState.IsValid)
            {
                db.SizeTypes.Add(sizeType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sizeType);
        }

        // GET: SizeTypes/Edit/5
        // GET: Brand/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SizeType sizeType = db.SizeTypes.Find(id);
            if (sizeType == null)
            {
                return HttpNotFound();
            }
            return View(sizeType);
        }

        // POST: SizeTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // GET: Brand/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "SizeTypeID,SizeTypeName")] SizeType sizeType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sizeType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sizeType);
        }

        // GET: SizeTypes/Delete/5
        // GET: Brand/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SizeType sizeType = db.SizeTypes.Find(id);
            if (sizeType == null)
            {
                return HttpNotFound();
            }
            return View(sizeType);
        }

        // POST: SizeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        // GET: Brand/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            SizeType sizeType = db.SizeTypes.Find(id);
            db.SizeTypes.Remove(sizeType);
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
