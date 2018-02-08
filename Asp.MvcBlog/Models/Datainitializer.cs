using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Asp.MvcBlog.Models
{
    public class Datainitializer :CreateDatabaseIfNotExists<Databasecontext>
    {
        protected override void Seed(Databasecontext context)
        {
            Uye admin = new Uye()
            {
                Ad = "Müleyke",
                Soyad = "Kaya",
                KullaniciAdi = "muleykekaya",
                AdminMi = true,
                ProfilResmi = "user.jpg",
                Sifre = "123",
                ActivateGuid = Guid.NewGuid(),
                Email = "muleykekaya@gmail.com",


            };

            Uye uye = new Uye()
            {
                Ad = "Melike",
                Soyad = "Kaya",
                KullaniciAdi = "melikekaya",
                ProfilResmi = "user.jpg",
                AdminMi = false,
                Sifre = "12",
                ActivateGuid = Guid.NewGuid(),
                Email = "muleykekaya@gmail.com",


            };

            for (int i = 0; i < 6; i++)
            {
                Uye uyeler = new Uye()
                {
                    Ad = FakeData.NameData.GetFirstName(),
                    Soyad = FakeData.NameData.GetSurname(),
                    KullaniciAdi = FakeData.NameData.GetFemaleFirstName(),
                    Sifre = "12",
                    ProfilResmi = "user.jpg",
                    AdminMi = false,
                    ActivateGuid = Guid.NewGuid(),
                    Email = FakeData.NetworkData.GetEmail()

                };
                context.Uyeler.Add(uyeler);

            }


            context.Uyeler.Add(admin);
            context.Uyeler.Add(uye);

            context.SaveChanges();

            List<Uye> KullaniciListesi = context.Uyeler.ToList();

            for (int i = 0; i < 10; i++)
            {


                Kategori kat = new Kategori()
                {

                    Baslik = FakeData.PlaceData.GetStreetName(),
                    Aciklama = FakeData.PlaceData.GetAddress(),



                };

                context.Kategoriler.Add(kat);


                for (int k = 0; k < FakeData.NumberData.GetNumber(1, 15); k++)
                {
                    Not not = new Not()
                    {
                        Baslik = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(5, 25)),
                        Yazi = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                        BegeniSayisi = FakeData.NumberData.GetNumber(1, 9),
                        Yazar = FakeData.NameData.GetFullName()

                    };

                    kat.Notlar.Add(not);

                    for (int m = 0; m < not.BegeniSayisi; m++)
                    {

                        Begeni begn = new Begeni()
                        {
                            BegenenKullanici = KullaniciListesi[m]
                        };



                        not.Begeniler.Add(begn);
                    }

                }
            }
            context.SaveChanges();
        }
    }
}