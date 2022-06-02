using final.Models;
using final.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final.Auth
{
    public class UyeServices
    {
        DB03Entities db = new DB03Entities();




        public UyeModel UyeOturumAc(string kadi, string parola)
        {
            UyeModel uye = db.Uye.Where(s => s.kullaniciAdi == kadi && s.sifre == parola).Select(x => 
            new UyeModel()
            {
                uyeId = x.uyeId,
                adSoyad = x.adSoyad,
                email = x.email,
                kullaniciAdi = x.kullaniciAdi,
                sifre = x.sifre,
                uyeAdmin = x.uyeAdmin

            }).SingleOrDefault();
            return uye;
        }
    }
}