using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project1.DAL;
using project1.Models;


namespace project1.Controllers
{
    public class SampleHashController : Controller
    {
        // GET: SampleHash
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string password)
        {
            PenggunaDAL penDAL = new PenggunaDAL();
            ViewBag.HasilHash = penDAL.GetMD5Hash(password);

            //ViewBag.HasilHash = password.GetHashCode();
            return View();
        }
    }
}