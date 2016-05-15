using GrocerCheckRebuild.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrocerCheckRebuild.Controllers
{
    public class HomeController : Controller
    {
        private GrocerCheckRebuildContext db = new GrocerCheckRebuildContext();

        public ActionResult Index()
        {
            return View();
        }


        //pbrooker: Ajax search start
        private List<Models.Item> GetItem(string searchString)
        {
            return db.Items
                .Where(c => c.Name.Contains(searchString) ||
                c.Grocer.GrocerName.Contains(searchString) ||
                c.Brand.BrandName.Contains(searchString) ||
                c.Size.SizeDescription.Contains(searchString) ||
                c.Category.CategoryName.Contains(searchString)).ToList();

        }

        public ActionResult ItemSearch(string q)
        {
            var item = GetItem(q);
            return PartialView("_ItemSearch", item);
        }

        public ActionResult QuickSearch(string term)
        {
            var item = GetItem(term)
                .Select(c => new { value = c.Name });
            return Json(item, JsonRequestBehavior.AllowGet);
        }

        //pbrooker: Ajax search end

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}