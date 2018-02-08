using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asp.MvcBlog.Models;

namespace Asp.MvcBlog.Islem
{
    public class RepositoryBase
    {
        protected static Databasecontext context;

        protected static object _lockSync = new object();

      
        protected RepositoryBase()//protected ile sadece
        {
            CreateContext();
        }

        private static void CreateContext()
        {
            if (context == null)
            {
                lock (_lockSync)//aynı anda iki parçaçık çalışmasın diye kitleme yapılır
                {
                    if (context == null)
                    {
                        context = new Databasecontext();
                    }
                }

            }
        }
    }
}