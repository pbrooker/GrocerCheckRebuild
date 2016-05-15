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
using GrocerCheckRebuild.Helpers;
using System.Threading.Tasks;

namespace GrocerCheckRebuild.Controllers
{
    public class BrandController : Controller
    {
        private GrocerCheckRebuildContext db = new GrocerCheckRebuildContext();

        // GET: Brand
        public ActionResult Index()
        {
            return View(db.Brands.ToList());
        }

        // GET: Brand/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // GET: Brand/Create
        // GET: Brand/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Brand/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // GET: Brand/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create([Bind(Include = "BrandName")] Brand brand, HttpPostedFileBase ImageName)
        {
            if (ModelState.IsValid)
            {
                //pbrooker: added image upload
                //Note the HttpPostedFileBase args in the method
                //Also the from needs a enctype="multipart/form-data"
                //and <input type="file" id="ImageName" name="ImageName" accept="image/*" class = "form-control"/>

                if (ImageName != null && ImageName.ContentLength > 0)
                {
                    //do we have anything to upload - yes
                    var validImageTypes = new string[]
                    {
                        //"image/gif",
                        //"image/jpg",
                        //"iamge/jpeg",
                        "image/png" 
                    };
                    if (!validImageTypes.Contains(ImageName.ContentType))
                    {
                        //file being uploaded is not a png - display error
                        ModelState.AddModelError("", "Please chose a PNG image.");
                        return View(brand);
                    }
                    db.Brands.Add(brand);
                    await db.SaveChangesAsync();
                    //Retrieve the Identity from SQL Server
                    string pictureName = brand.BrandID.ToString();

                    //rename scale and upload image
                    ImageUpload imageUpload = new ImageUpload { Height = 100 };
                    ImageResult imageResult = imageUpload.RenameUploadFile(ImageName, pictureName);

                    return RedirectToAction("Index");
                }
                else
                {

                    var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { x.Key, x.Value.Errors })
                    .ToArray();
                    //nothing to upload - display error
                    ModelState.AddModelError("", "You have not selected an image file to upload.");
                    return View(brand);
                }
            }
                return View(brand);
        }

        // GET: Brand/Edit/5
        // GET: Brand/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // POST: Brand/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BrandID,BrandName")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brand);
        }

        // GET: Brand/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // POST: Brand/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        // GET: Brand/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Brand brand = db.Brands.Find(id);
            db.Brands.Remove(brand);
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
