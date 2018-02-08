using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Asp.MvcBlog.Models
{
    public class Uye
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("İsim"),
            StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Ad { get; set; }

        [DisplayName("Soyad"),
            StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Soyad { get; set; }

        [DisplayName("Kullanıcı Adı"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string KullaniciAdi { get; set; }

        [DisplayName("E-Posta"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(70, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Email { get; set; }

        [DisplayName("Şifre"),
            Required(ErrorMessage = "{0} alanı gereklidir."),
            StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Sifre { get; set; }

        [DisplayName("Yönetici")]
        public bool AdminMi { get; set; }

        [Required, ScaffoldColumn(false)]
        public Guid ActivateGuid { get; set; }

        [StringLength(30), ScaffoldColumn(false)]
        public string ProfilResmi { get; set; }
    }
}