using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project1.DAL;
using project1.Models;
using System.Data.Entity;
using System.Data;
using System.Net;
using System.IO;

using System.Security.Cryptography; //untuk membuat password md5
using System.Data.SqlClient;
using System.Text;


namespace project1.Controllers
{
    public class RegistrasiController : Controller
    {
        private Sample db = new Sample();
        // GET: Registrasi
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Pengguna pengguna)
        {
            PenggunaDAL pengDAL = new PenggunaDAL();
            try
            {
                if(ModelState.IsValid)
                {
                    pengDAL.Refistrasi(pengguna);
                    ViewBag.Pesan = "Data Pengguna Berhasil Ditambah !";
                }
                return View();
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }

        }
        public ActionResult Login()
        {
            return View();
        }
        
    }
}