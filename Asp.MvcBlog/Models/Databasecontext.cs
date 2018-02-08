using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Asp.MvcBlog.Models
{
    public class Databasecontext:DbContext
    {
        public DbSet<Uye> Uyeler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Not> Notlar { get; set; }
        public DbSet<Begeni> Begeniler { get; set; }

        public Databasecontext()
        {
            Database.SetInitializer(new Datainitializer());
        }
    }
}