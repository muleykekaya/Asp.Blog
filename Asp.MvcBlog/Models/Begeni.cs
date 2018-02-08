using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Asp.MvcBlog.Models
{
    public class Begeni
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual Not Not { get; set; }
        public virtual Uye BegenenKullanici { get; set; }
    }
}