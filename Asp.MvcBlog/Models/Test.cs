using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asp.MvcBlog.Models;

namespace Asp.MvcBlog.Models
{
    public class Test
    {
        public Test()
        {
            Databasecontext db = new Databasecontext();
            db.Kategoriler.ToList();
        }
    }
}