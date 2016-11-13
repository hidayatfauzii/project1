using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project1.Models;

namespace project1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (OurDbContext db = new OurDbContext())
            {
                return View(db.pengguna.ToList());
            }
   
        }

        public ActionResult Regis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Regis(Pengguna pengguna)
        {
            if (ModelState.IsValid)
            {
                using (OurDbContext db = new OurDbContext())
                {
                    db.pengguna.Add(pengguna);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = pengguna.Username + " " + "Registrasi Berhasil.";
            }
            return View();
        }
        // login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Pengguna pengguna)
        {
            using (OurDbContext db = new OurDbContext())
            {
                var login = db.pengguna.Single(u => u.Username == pengguna.Username && u.Password == pengguna.Password);
                if(login != null)
                {
                    Session["UserID"] = login.UserID.ToString();
                    Session["Username"] = login.Username.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("","Username atau passwor salah.");
                }
            }
            return View();
        }
        public ActionResult LoggedIn()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}