using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Data;
using System.Data.Entity;
using System.Web.Mvc;
using System.IO;
using project1.DAL;
using project1.Models;

namespace project1.Controllers
{
    public class CategoriesController : Controller
       
    {
        private Sample db = new Sample();
        // GET: Categories
        public ViewResult Index(string searchstring)
        {

            var catdal = from c in db.Categories
                         select c;
            if (!String.IsNullOrEmpty(searchstring))
            {
                catdal = catdal.Where(c => c.CategoryName.Contains(searchstring) || c.CategoryName.Contains(searchstring));
            }
            return View(catdal.ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                // TODO: Add insert logic here
                CategoriesDAL cat = new CategoriesDAL();
                cat.Create(category);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Category catdal = db.Categories.Find(id);
            if (catdal == null)
            {
                return HttpNotFound();
            }
            return View(catdal);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category categori)
        {
           if (ModelState.IsValid)
            {
                db.Entry(categori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categori);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Category catdal = db.Categories.Find(id);
            if (catdal == null)
            {
                return HttpNotFound();
            }
            return View(catdal);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Category catdal = db.Categories.Find(id);
            db.Categories.Remove(catdal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
