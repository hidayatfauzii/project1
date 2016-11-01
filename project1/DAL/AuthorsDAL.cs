using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using project1.Models;
namespace project1.DAL
{
    public class AuthorsDAL
    {
        private Sample db;
        public AuthorsDAL()
        {
            db = new Sample();
        }
        public IQueryable<Author> GetAll()
        {
            var result = from c in db.Authors
                         orderby c.FirstName ascending
                         select c;

            return result;
        }
        public Author GetById(int id)
        {
            var result = (from c in db.Authors
                          where c.AuthorID == id
                          select c).FirstOrDefault();
            if (result != null)
                return result;
            else
                throw new Exception("Data dengan kode id " + id.ToString() + " TIdak  Ditemukan");
        }
        public void Create(Author authors)
        {
            try
            {
                db.Authors.Add(authors);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("error : " + ex.Message);
            }
        }
    }
}