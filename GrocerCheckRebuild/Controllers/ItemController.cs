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
using GrocerCheckRebuild.ViewModels;

namespace GrocerCheckRebuild.Controllers
{
    public class ItemController : Controller
    {
        private GrocerCheckRebuildContext db = new GrocerCheckRebuildContext();

        //GET: Item
        public ActionResult Index(int? ItemID, int? BrandID, int? CategoryID, int? SizeID, int? GrocerID)
        {
            //var items = db.Items.Include(i => i.Brand).Include(i => i.Category).Include(i => i.Grocer).Include(i => i.Size).Include(i => i.SizeType);
            //return View(items.ToList());

            //pbrooker: item index drill down 
            var viewModel = new ItemIndexData();

            viewModel.Brands = db.Brands
                .Include(i => i.Grocers)
                .Include(i => i.Sizes)
                .Include(i => i.Categories)
                .Include(i => i.Items)
                .OrderBy(i => i.BrandName);


            //If a brand has been selected, get the categories associated with that brand
            if (BrandID != null)
            {
                ViewBag.BrandID = BrandID.Value;

                viewModel.Categories = viewModel.Brands
                                        .Where(i => i.BrandID == BrandID.Value).Single().Categories;

                var BrandName = viewModel.Brands.Where(i => i.BrandID == BrandID.Value).Single();
                ViewBag.BrandName = BrandName.BrandName;
               
            }

            //If a category has been selected, get the items associated with that category
            if(CategoryID!=null)
            {
                ViewBag.CategoryID = CategoryID.Value;

                viewModel.Items = viewModel.Categories
                                    .Where(i => i.CategoryID == CategoryID.Value).Single().Items;

                var CategoryName = viewModel.Categories.Where(i => i.CategoryID == CategoryID.Value).Single();
                ViewBag.CategoryName = CategoryName.CategoryName;

            }


            return View(viewModel);
        }

        public ActionResult AdminIndex()
        {
            var items = db.Items.Include(i => i.Brand).Include(i => i.Category).Include(i => i.Grocer).Include(i => i.Size).Include(i => i.SizeType);
            return View(items.ToList());
        }

        // GET: Item/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Item/Create
        // GET: Brand/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName");
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.GrocerID = new SelectList(db.Grocers, "GrocerID", "GrocerName");
            ViewBag.SizeID = new SelectList(db.Sizes, "SizeID", "SizeDescription");
            ViewBag.SizeTypeID = new SelectList(db.SizeTypes, "SizeTypeID", "SizeTypeName");
            return View();
        }

        // POST: Item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // GET: Brand/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Name,StandardID,Price,SizeMeasure,CalculatedPrice,SizeID,BrandID,CategoryID,GrocerID,SizeTypeID")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName", item.BrandID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", item.CategoryID);
            ViewBag.GrocerID = new SelectList(db.Grocers, "GrocerID", "GrocerName", item.GrocerID);
            ViewBag.SizeID = new SelectList(db.Sizes, "SizeID", "SizeDescription", item.SizeID);
            ViewBag.SizeTypeID = new SelectList(db.SizeTypes, "SizeTypeID", "SizeTypeName", item.SizeTypeID);
            return View(item);
        }

        // GET: Item/Edit/5
        // GET: Brand/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName", item.BrandID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", item.CategoryID);
            ViewBag.GrocerID = new SelectList(db.Grocers, "GrocerID", "GrocerName", item.GrocerID);
            ViewBag.SizeID = new SelectList(db.Sizes, "SizeID", "SizeDescription", item.SizeID);
            ViewBag.SizeTypeID = new SelectList(db.SizeTypes, "SizeTypeID", "SizeTypeName", item.SizeTypeID);
            return View(item);
        }

        // POST: Item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // GET: Brand/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "ItemID,Name,StandardID,Price,SizeMeasure,CalculatedPrice,SizeID,BrandID,CategoryID,GrocerID,SizeTypeID")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "BrandName", item.BrandID);
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", item.CategoryID);
            ViewBag.GrocerID = new SelectList(db.Grocers, "GrocerID", "GrocerName", item.GrocerID);
            ViewBag.SizeID = new SelectList(db.Sizes, "SizeID", "SizeDescription", item.SizeID);
            ViewBag.SizeTypeID = new SelectList(db.SizeTypes, "SizeTypeID", "SizeTypeName", item.SizeTypeID);
            return View(item);
        }

        // GET: Item/Delete/5
        // GET: Brand/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        // GET: Brand/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
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
