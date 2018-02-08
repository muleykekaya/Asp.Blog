using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Asp.MvcBlog.Models
{
    public class Not
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Not Başlığı"), Required, StringLength(60)]
        public string Baslik { get; set; }

        [DisplayName("Not Metni"), Required, StringLength(2000)]
        public string Yazi { get; set; }


        [DisplayName("Beğenilme")]
        public int BegeniSayisi { get; set; }

        [DisplayName("Kategori")]
        public int KategoriId { get; set; }

        [DisplayName("Yazar"),
          Required(ErrorMessage = "{0} alanı gereklidir."),
          StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Yazar { get; set; }


        public virtual Kategori Kategori { get; set; }
        public virtual List<Begeni> Begeniler { get; set; }


        public Not()
        {

            Begeniler = new List<Begeni>();
        }
    }
}