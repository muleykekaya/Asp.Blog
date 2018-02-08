using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asp.MvcBlog.Islem
{//Birden Fazla Hata Mesajı Döndürmek İçin
    public class Sonuc<T> where T:class
    {
        public List<string> Errors { get; set; }
        public T Sonucc { get; set; }

        public Sonuc()
        {
            Errors = new List<string>();
        }
    }
}