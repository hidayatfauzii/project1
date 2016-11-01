using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using project1.Models;

namespace project1.DAL
{
    public class CategoriesDAL
    {
        private Sample db;
        public CategoriesDAL()
        {
            db = new Sample();
        }

        public IQueryable<Category> GetAll()
        {
            var result = from C in db.Categories
                         orderby C.CategoryName ascending
                         select C;
            return result;
        }
        public Category GetById(int id)
        {
            var result = (from c in db.Categories
                          where c.IdCategory == id
                          select c).FirstOrDefault();
            if (result != null)
                return result;
            else
                throw new Exception("Data dengan no ID " + id.ToString() + " Tidak ditemukan!");
        }
        public void Create(Category category)
        {
            try
            {
                db.Categories.Add(category);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }
    }
}