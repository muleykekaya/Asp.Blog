using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Asp.MvcBlog.Models
{
    public class Kategori
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Kategori"),
           Required(ErrorMessage = "{0} alanı gereklidir."),
           StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter içermeli.")]
        public string Baslik { get; set; }

        [DisplayName("Açıklama"),
            StringLength(150, ErrorMessage = "{0} alanı max. {1} karakter içermeli.")]
        public string Aciklama { get; set; }

        public virtual List<Not> Notlar { get; set; }

        public Kategori()
        {
            Notlar = new List<Not>();
        }

    }
}