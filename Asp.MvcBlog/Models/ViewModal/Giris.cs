using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Asp.MvcBlog.Models.ViewModal
{
    public class Giris
    {
        [DisplayName("Kullanıcı Adı"), Required(ErrorMessage = "{0} alanı boş geçilemez.."), StringLength(25, ErrorMessage = "{0} max {1} karakter olmalıdır.")]
        public string KullaniciAdi { get; set; }
        [DisplayName("Şifre"), Required(ErrorMessage = "{0} alanı boş geçilemez.."), StringLength(25, ErrorMessage = "{0} max {1} karakter olmalıdır.")]
        public string Sifre { get; set; }
    }
}