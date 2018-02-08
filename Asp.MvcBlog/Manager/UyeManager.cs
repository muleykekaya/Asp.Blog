using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Asp.MvcBlog.Islem;
using Asp.MvcBlog.Models;
using Asp.MvcBlog.Models.ViewModal;

namespace Asp.MvcBlog.Manager
{
    public class UyeManager
    {
        private Repository<Uye> repo_uye = new Repository<Uye>();
      

        public Sonuc<Uye> KayitUye(Kayit data)
        {
            Uye uye = repo_uye.Bul(x => x.KullaniciAdi == data.KullaniciAdi || x.Email == data.EMail);//kullanıcı var mı
            Sonuc<Uye> snc = new Sonuc<Uye>();
            if (uye != null)//varsa
            {
                if (uye.KullaniciAdi == data.KullaniciAdi)
                {
                    snc.Errors.Add("Kullanıcı Kayıtlı.");
                }

                if (uye.Email == data.EMail)
                {
                    snc.Errors.Add("E-mail Kayıtlı.");
                }
            }
            else
            {
                int dbsonuc = repo_uye.Ekle(new Uye()
                {
                    KullaniciAdi = data.KullaniciAdi,
                    Email = data.EMail,
                    Sifre = data.Sifre,
                    AdminMi=false,
                    ActivateGuid=Guid.NewGuid(),
                    
                });

                if (dbsonuc > 0)
                {
               snc.Sonucc= repo_uye.Bul(x => x.KullaniciAdi == data.KullaniciAdi && x.Email == data.EMail);
                }
            }

            return snc;
        }

        public Sonuc<Uye> GirisUye(Giris data)
        {
            Sonuc<Uye> snc = new Sonuc<Uye>();
            snc.Sonucc= repo_uye.Bul(x => x.KullaniciAdi == data.KullaniciAdi && x.Sifre == data.Sifre);//kullanıcı var mı
           
            if(snc.Sonucc==null)
            {
                snc.Errors.Add("Kullanıcı Bulunamadı.Lütfen Kayıt Olun.");
            }
            return snc;
        }

        public Sonuc<Uye> UyeGetir(int id)
        {
            Sonuc<Uye> snc = new Sonuc<Uye>();
            snc.Sonucc = repo_uye.Bul(x => x.Id == id);
            if (snc.Sonucc==null)
            {
                snc.Errors.Add("Kullanıcı Bulunamadı.");
            }
            return snc;
        }

      

        public Sonuc<Uye> ProfilDüzenle(Uye data)
        {
            Uye db_user = repo_uye.Bul(x => x.Id != data.Id && (x.Ad == data.Ad || x.Email == data.Email));
            Sonuc<Uye> snc = new Sonuc<Uye>();

            if (db_user != null && db_user.Id != data.Id)
            {
                if (db_user.Ad == data.Ad)
                {
                    snc.Errors.Add( "Kullanıcı adı kayıtlı.");
                }

                if (db_user.Email == data.Email)
                {
                    snc.Errors.Add( "E-posta adresi kayıtlı.");
                }

                return snc;
            }

            snc.Sonucc = repo_uye.Bul(x => x.Id == data.Id);
            snc.Sonucc.Email = data.Email;
            snc.Sonucc.Ad = data.Ad;
            snc.Sonucc.Soyad = data.Soyad;
            snc.Sonucc.Sifre = data.Sifre;
            snc.Sonucc.KullaniciAdi = data.KullaniciAdi;

            if (string.IsNullOrEmpty(data.ProfilResmi) == false)
            {
                snc.Sonucc.ProfilResmi = data.ProfilResmi;
            }

            if (repo_uye.Güncelle(snc.Sonucc) == 0)
            {
                snc.Errors.Add("Profil güncellenemedi.");
            }

            return snc;
        }

        public  Sonuc<Uye> UyeSil(int id)
        {
            Sonuc<Uye> snc = new Sonuc<Uye>();
            Uye uye = repo_uye.Bul(x => x.Id == id);

            if (uye != null)
            {
                if (repo_uye.Sil(uye) == 0)
                {
                    snc.Errors.Add( "Kullanıcı silinemedi.");
                    return snc;
                }
            }
            else
            {
                snc.Errors.Add("Kullanıcı bulunamadı.");
            }

            return snc;
        }
    }
}