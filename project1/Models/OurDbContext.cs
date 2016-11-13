using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace project1.Models
{
    public class OurDbContext : DbContext
    {
        public DbSet<Pengguna> pengguna { get; set; }
    }
}