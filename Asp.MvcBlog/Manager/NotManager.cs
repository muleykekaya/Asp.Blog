using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asp.MvcBlog.Islem;
using Asp.MvcBlog.Models;

namespace Asp.MvcBlog.Manager
{
    public class NotManager
    {
        private Repository<Not> repo_not = new Repository<Not>();

        public List<Not> GetNot()
        {
            return repo_not.Listele();
        }
    }
}