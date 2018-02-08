using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Asp.MvcBlog.Islem;
using Asp.MvcBlog.Manager;
using Asp.MvcBlog.Models;
using Asp.MvcBlog.Models.ViewModal;

namespace Asp.MvcBlog.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Test t = new Test();
            NotManager nm = new NotManager();
            return View(nm.GetNot());
        }

        public ActionResult ByKategori(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            KategoriManager km = new KategoriManager();
            Kategori k = km.GetKategoriId(id.Value);

            if (k == null)
            {
                return HttpNotFound();
            }

            return View("Index", k.Notlar);
        }

        public ActionResult Hakkimizda()
        {
            return View();
        }

        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(Giris model)
        {
            if (ModelState.IsValid)
            {
                UyeManager um = new UyeManager();
                Sonuc<Uye> snc = um.GirisUye(model);
                if (snc.Errors.Count > 0)
                {
                    snc.Errors.ForEach(x => ModelState.AddModelError("", x));
                    return View(model);
                }

                Current.Set<Uye>("üye", snc.Sonucc);  /* Session["üye"] = snc.Sonucc;*///kullanıcıyı tutma
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(Kayit model)
        {

            if (ModelState.IsValid)
            {
                UyeManager um = new UyeManager();
                Sonuc<Uye> son = um.KayitUye(model);
                if (son.Errors.Count>0)
                {
                    son.Errors.ForEach(x => ModelState.AddModelError("", x));
                    return View(model);
                }
                return RedirectToAction("KayitTamam");
            }
            return View(model);
        }

        public ActionResult KayitTamam()
        {
            return View();

        }
        public ActionResult CikisYap()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult ProfilGöster()
        {
          
            UyeManager um = new UyeManager();
            Sonuc<Uye> snc = um.UyeGetir(Current.Uye.Id);
            //if (snc.Errors.Count>0)
            //{
                
            //}
            return View(snc.Sonucc);
        }
        public ActionResult ProfilGüncelle()
        {
            UyeManager um = new UyeManager();
            Sonuc<Uye> snc = um.UyeGetir(Current.Uye.Id);
            if (snc.Errors.Count > 0)
            {

            }
            return View(snc.Sonucc);

        }
        [HttpPost]
        public ActionResult ProfilGüncelle(Uye model,HttpPostedFileBase ProfilResmi)
        {
            UyeManager um = new UyeManager();
           
            //ModelState.Remove("ModifiedUsername");

             if (ProfilResmi != null &&
                    (ProfilResmi.ContentType == "image/jpeg" ||
                    ProfilResmi.ContentType == "image/jpg" ||
                    ProfilResmi.ContentType == "image/png"))
                {
                    string filename = $"user_{model.Id}.{ProfilResmi.ContentType.Split('/')[1]}";

                    ProfilResmi.SaveAs(Server.MapPath($"~/Resim/{filename}"));
                    model.ProfilResmi = filename;
                }

                Sonuc<Uye> snc = um.ProfilDüzenle(model);

                if (snc.Errors.Count > 0)
                {
                    snc.Errors.Add("Hata Oluştu");

                }

            // Profil güncellendiği için session güncellendi.
            Current.Set<Uye>("üye", snc.Sonucc);
            //Session["üye"] = snc.Sonucc;

            return RedirectToAction("ProfilGöster");
     

       
        }
        public ActionResult ProfilSil()
        {
            UyeManager um = new UyeManager();
            Sonuc<Uye> snc   =um.UyeSil(Current.Uye.Id);
             
                      

            if (snc.Errors.Count > 0)
            {
                snc.Errors.Add("Hata Oluştu");
            }

            Session.Clear();

            return RedirectToAction("Index");
        }
    }
}