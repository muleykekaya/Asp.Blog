using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asp.MvcBlog.Islem;
using Asp.MvcBlog.Models;

namespace Asp.MvcBlog.Manager
{
    public class KategoriManager
    {
        private Repository<Kategori> repo_kat = new Repository<Kategori>();

        public List<Kategori> GetKategori()
        {
            return repo_kat.Listele();
        }

        public Kategori GetKategoriId(int id)
        {
            return repo_kat.Bul(x => x.Id == id);
        }
    }
}