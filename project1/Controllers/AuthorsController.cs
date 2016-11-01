using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Web.Mvc;
using project1.DAL;
using project1.Models;
using project1.Controllers;

namespace project1.Controllers
{
    public class AuthorsController : Controller
    {
        private Sample db = new Sample();
        // GET: Authors
        public ActionResult Index(string SearchString)
        {
            var autdal = from a in db.Authors
                         select a;
            if (!String.IsNullOrEmpty(SearchString))
            {
                autdal = autdal.Where(a => a.FirstName.Contains(SearchString) || a.FirstName.Contains(SearchString));
            }
            return View(autdal.ToList());
        }

        // GET: Authors/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        [HttpPost]
        public ActionResult Create(Author author)
        {
            try
            {
                // TODO: Add insert logic here
                AuthorsDAL auto = new AuthorsDAL();
                auto.Create(author);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author autdal = db.Authors.Find(id);
            if (autdal == null)
            {
                return HttpNotFound();
            }
            return View(autdal);
        }

        // POST: Authors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author autdal = db.Authors.Find(id);
            if (autdal == null)
            {
                return HttpNotFound();
            }
            return View(autdal);
        }

        // POST: Authors/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Author autdal = db.Authors.Find(id);
            db.Authors.Remove(autdal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
