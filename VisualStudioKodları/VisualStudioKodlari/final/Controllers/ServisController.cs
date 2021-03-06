using final.Models;
using final.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace final.Controllers
{
    
    public class ServisController : ApiController
    {
        DB03Entities db = new DB03Entities();
        SonucModel sonuc = new SonucModel();

        #region Kategori
        [HttpGet]
        [Route("api/kategoriliste")]
        


        public List <KategoriModel> KategoriListe()
        {
            List<KategoriModel> liste = db.Kategori.Select(x => new KategoriModel()
            {
                kategoriId=x.kategoriId,
                kategoriAdi=x.kategoriAdi

            }).ToList();

            return liste;
        }

        [HttpGet]
        [Route("api/kategoribyid/{katId}")]
        public KategoriModel KategoriById(int katId)
        {
            KategoriModel kayit = db.Kategori.Where(s => s.kategoriId == katId).Select(x => 
            new KategoriModel() {

                kategoriId = x.kategoriId,
                kategoriAdi = x.kategoriAdi

            }).SingleOrDefault();
            return kayit;
        }

        [HttpPost]
        [Route("api/kategoriekle")]
        public SonucModel KategoriEkle(KategoriModel model)
        {
            if (db.Kategori.Count(s=>s.kategoriAdi==model.kategoriAdi) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen Kategori Adı Kayıtlıdır!";
                return sonuc;
            }

            Kategori yeni = new Kategori();
            yeni.kategoriAdi = model.kategoriAdi;
            db.Kategori.Add(yeni);
            try
            {
                db.SaveChangesAsync();
            }
             catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            sonuc.islem = true;
            sonuc.mesaj = "Kategori Eklendi!";
            return sonuc;
        }

        [HttpPut]
        [Route("api/kategoriduzenle")]
        public SonucModel KategoriDuzenle(KategoriModel model)
        {
            Kategori kayit = db.Kategori.Where(s => s.kategoriId == 
            model.kategoriId).FirstOrDefault();

            if (kayit==null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            kayit.kategoriAdi = model.kategoriAdi;
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Kategori Düzenlendi!";
            return sonuc;
        }

        [HttpDelete]
        [Route("api/kategorisil/{katId}")]
        public SonucModel KategoriSil(int katId)
        {
            Kategori kayit = db.Kategori.Where(s => s.kategoriId ==katId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            if (db.Haber.Count(s=>s.haberKategoriId==katId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Üzerinde Haber Kayıtlı Kategori Silinemez!";
                return sonuc;
            }

            db.Kategori.Remove(kayit);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Kategori Silindi!";

            return sonuc;
        }

        #endregion

        #region Haber
        

        [HttpGet]
        [Route("api/haberliste")]
        public List<HaberModel> HaberListe()
        {
            List<HaberModel> liste = db.Haber.Select(x => new HaberModel()
            {
                haberId=x.haberId,
                haberBaslik=x.haberBaslik,
                haberDetay=x.haberDetay,
                haberKategoriId=x.haberKategoriId,
                kategoriAdi=x.Kategori.kategoriAdi,
                haberOkuma=x.haberOkuma,
                haberTarih=x.haberTarih,
                haberUyeId=x.haberUyeId,
                uyeKadi=x.Uye.kullaniciAdi,
                
      
            }).ToList();

            return liste;

        }

        [HttpGet]
        [Route("api/haberlistebykatid/{katId}")]
        public List<HaberModel> HaberListeBykatId(int katId)
        {
            List<HaberModel> liste = db.Haber.Where(s=>s.haberKategoriId==katId).Select(x 
                => new HaberModel()
            {
                haberId = x.haberId,
                haberBaslik = x.haberBaslik,
                haberDetay = x.haberDetay,
                haberKategoriId = x.haberKategoriId,
                kategoriAdi = x.Kategori.kategoriAdi,
                haberOkuma = x.haberOkuma,
                haberTarih = x.haberTarih,
                haberUyeId = x.haberUyeId,
                uyeKadi = x.Uye.kullaniciAdi,


            }).ToList();

            return liste;

        }

        [HttpGet]
        [Route("api/haberlistebyuyeid/{uyeId}")]
        public List<HaberModel> HaberListeByUyeId(int uyeId)
        {
            List<HaberModel> liste = db.Haber.Where(s => s.haberUyeId == uyeId).Select(x
                    => new HaberModel()
                    {
                        haberId = x.haberId,
                        haberBaslik = x.haberBaslik,
                        haberDetay = x.haberDetay,
                        haberKategoriId = x.haberKategoriId,
                        kategoriAdi = x.Kategori.kategoriAdi,
                        haberOkuma = x.haberOkuma,
                        haberTarih = x.haberTarih,
                        haberUyeId = x.haberUyeId,
                        uyeKadi = x.Uye.kullaniciAdi,


                    }).ToList();

            return liste;

        }


        [HttpGet]
        [Route("api/haberbyid/{haberId}")]

        public HaberModel HaberById(int haberId)
        {
            HaberModel kayit = db.Haber.Where(s => s.haberId == haberId).Select(x => new HaberModel()
            {
                haberId = x.haberId,
                haberBaslik = x.haberBaslik,
                haberDetay = x.haberDetay,
                haberKategoriId = x.haberKategoriId,
                kategoriAdi = x.Kategori.kategoriAdi,
                haberOkuma = x.haberOkuma,
                haberTarih = x.haberTarih,
                haberUyeId = x.haberUyeId,
                uyeKadi = x.Uye.kullaniciAdi,

            }).SingleOrDefault();
            return kayit;
        }


        [HttpPost]
        [Route("api/haberekle")]

        public SonucModel HaberEkle(HaberModel model)
        {
            if (db.Haber.Count(s => s.haberBaslik == model.haberBaslik) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Haber Başlığı Kayıtlıdır!";
                return sonuc;
            }

            Haber yeni = new Haber();
            yeni.haberBaslik = model.haberBaslik;
            yeni.haberDetay = model.haberDetay;
            yeni.haberTarih = model.haberTarih;
            yeni.haberOkuma = model.haberOkuma;
            yeni.haberKategoriId = model.haberKategoriId;
            yeni.haberUyeId = model.haberUyeId;
            db.Haber.Add(yeni);
            db.SaveChangesAsync();

            sonuc.islem = true;
            sonuc.mesaj = "Haber Eklendi!";

            return sonuc;
        }

        [HttpPut]
        [Route("api/haberduzenle")]
        public SonucModel HaberDuzenle(HaberModel model)
        {
            Haber kayit = db.Haber.Where(s=>s.haberId==model.haberId).SingleOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            kayit.haberBaslik = model.haberBaslik;
            kayit.haberDetay = model.haberDetay;
            kayit.haberTarih = model.haberTarih;
            kayit.haberOkuma = model.haberOkuma;
            kayit.haberKategoriId = model.haberKategoriId;
            kayit.haberUyeId = model.haberUyeId;
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Haber Düzenlendi!";

            return sonuc;


        }

        [HttpDelete]
        [Route("api/habersil/{haberId}")]
        public SonucModel HaberSil(int haberId)
        {
            Haber kayit = db.Haber.Where(s => s.haberId == haberId).SingleOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }

            if (db.Yorum.Count(s => s.haberId == haberId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Üzerinde Yorum Kayıtlı Olan Haber Silinemez!";
            }

            db.Haber.Remove(kayit);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Haber Silindi!";

            return sonuc;
        }





        #endregion

        #region Üye

        [HttpGet]
        [Route("api/uyeliste")]
        public List<UyeModel> UyeListe()
        {
            List<UyeModel> liste = db.Uye.Select(x => new UyeModel()
            {
                uyeId=x.uyeId,
                adSoyad=x.adSoyad,
                email=x.email,
                kullaniciAdi=x.kullaniciAdi,
                sifre=x.sifre,
                uyeAdmin=x.uyeAdmin
            }).ToList();

            return liste;
        }
        [HttpGet]
        [Route("api/uyebyid/{uyeId}")]
        public UyeModel UyeById (int uyeId)
        {
            UyeModel kayit = db.Uye.Where(s => s.uyeId == uyeId).Select(x => new UyeModel()
            {
                uyeId = x.uyeId,
                adSoyad = x.adSoyad,
                email = x.email,
                kullaniciAdi = x.kullaniciAdi,
                sifre = x.sifre,
                uyeAdmin = x.uyeAdmin

            }).SingleOrDefault();

            return kayit;
        }
        [HttpPost]
        [Route("api/uyeekle")]
        public SonucModel UyeEkle(UyeModel model)
        {
            if (db.Uye.Count(s=>s.kullaniciAdi==model.kullaniciAdi || s.email==model.email)> 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen Kullanıcı Adı veya E-posta adresi Kayıtlıdır.";
                return sonuc;
            }

            Uye yeni = new Uye();
            yeni.adSoyad = model.adSoyad;
            yeni.email =model.email;
            yeni.kullaniciAdi = model.kullaniciAdi;
            yeni.sifre = model.sifre;
            yeni.uyeAdmin = model.uyeAdmin;

            db.Uye.Add(yeni);
            db.SaveChangesAsync();

            sonuc.islem = true;
            sonuc.mesaj = "Üye Eklendi";

            return sonuc;
        }

        [HttpPut]
        [Route("api/uyeduzenle")]
        public SonucModel UyeDuzenle(UyeModel model)
        {
            Uye kayit = db.Uye.Where(s => s.uyeId == model.uyeId).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı";

                return sonuc;
            }
            kayit.adSoyad = model.adSoyad;
            kayit.email = model.email;
            kayit.kullaniciAdi = model.kullaniciAdi;
            kayit.sifre = model.sifre;
            kayit.uyeAdmin = model.uyeAdmin;

            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Üye Düzenlendi";

            return sonuc;
        }

        [HttpDelete]
        [Route("api/uyesil/{uyeId}")]
        public SonucModel UyeSil(int uyeId)
        {
            Uye kayit = db.Uye.Where(s => s.uyeId == uyeId).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı";

                return sonuc;
            }

if (db.Haber.Count(s=>s.haberUyeId== uyeId)> 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Üzerinde Haber Kayıdı Olan Üye Silinemez";
                return sonuc;

            }
            if (db.Yorum.Count(s => s.uyeId == uyeId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Üzerinde Yorum Kayıdı Olan Üye Silinemez";
                return sonuc;

            }

            db.Uye.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Üye Silindi.";

            return sonuc;
        }


        #endregion

        #region Yorum

        [HttpGet]
        [Route("api/yorumliste")]
        public List<YorumModel> YorumListe()
        {
            List<YorumModel> liste = db.Yorum.Select(x => new YorumModel()
            {
                yorumId=x.yorumId,
                yorumIcerik=x.yorumIcerik,
                haberId=x.haberId,
                uyeId=x.uyeId,
                tarih=x.tarih,
                kullaniciAdi = x.Uye.kullaniciAdi,
                haberBaslik = x.Haber.haberBaslik

            }).ToList();
            return liste;
        }
        [HttpGet]
        [Route("api/yorumlistebyuyeid/{uyeId}")]
        public List<YorumModel> YorumListeByUyeId(int uyeId)
        {
            List<YorumModel> liste = db.Yorum.Where(s=>s.uyeId==uyeId).Select(x => new 
            YorumModel()
            {
                yorumId = x.yorumId,
                yorumIcerik = x.yorumIcerik,
                haberId = x.haberId,
                uyeId = x.uyeId,
                tarih = x.tarih,
                kullaniciAdi=x.Uye.kullaniciAdi,
                haberBaslik=x.Haber.haberBaslik

            }).ToList();
            return liste;
        }
        [HttpGet]
        [Route("api/yorumlistebyhaberid/{haberId}")]
        public List<YorumModel> YorumListeByHaberId(int haberId)
        {
            List<YorumModel> liste = db.Yorum.Where(s => s.haberId == haberId).Select(x => 
            new YorumModel()
            {
                yorumId = x.yorumId,
                yorumIcerik = x.yorumIcerik,
                haberId = x.haberId,
                uyeId = x.uyeId,
                tarih = x.tarih,
                kullaniciAdi = x.Uye.kullaniciAdi,
                haberBaslik = x.Haber.haberBaslik

            }).ToList();
            return liste;
        }

        [HttpGet]
        [Route("api/yorumbyid/{yorumId}")]
        public YorumModel YorumById(int yorumId)
        {
            YorumModel kayit = db.Yorum.Where(s => s.yorumId == yorumId).Select(x => new 
            YorumModel() {

                yorumId = x.yorumId,
                yorumIcerik = x.yorumIcerik,
                haberId = x.haberId,
                uyeId = x.uyeId,
                tarih = x.tarih,
                kullaniciAdi = x.Uye.kullaniciAdi,
                haberBaslik = x.Haber.haberBaslik

            }).SingleOrDefault();

            return kayit;

        }

        [HttpPost]
        [Route("api/yorumekle")]

        public SonucModel YorumEkle(YorumModel model)
        {
            if (db.Yorum.Count(s=>s.uyeId==model.uyeId && s.haberId==model.haberId && 
            s.yorumIcerik==model.yorumIcerik)> 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Aynı Kişi Aynı Habere Aynı Yorumu Yapamaz.";
                return sonuc;
            }

            Yorum yeni = new Yorum();
            yeni.yorumId = model.yorumId;
            yeni.yorumIcerik = model.yorumIcerik;
            yeni.haberId = model.haberId;
            yeni.uyeId = model.uyeId;
            yeni.tarih = model.tarih;
            db.Yorum.Add(yeni);
            db.SaveChangesAsync();

            sonuc.islem = true;
            sonuc.mesaj = "Yorum Eklendi";


            return sonuc;

        }

        [HttpPut]
        [Route("api/yorumduzenle")]

        public SonucModel YorumDuzenle(YorumModel model)
        {

            Yorum kayit = db.Yorum.Where(s => s.yorumId == model.yorumId).SingleOrDefault();

            if (kayit == null)  
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı";
                return sonuc;

            }
            kayit.yorumId = model.yorumId;
            kayit.yorumIcerik = model.yorumIcerik;
            kayit.haberId = model.haberId;
            kayit.uyeId = model.uyeId;
            kayit.tarih = model.tarih;
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Yorum Düzenlendi";


            return sonuc;
        }

        [HttpDelete]
        [Route("api/yorumsil/{yorumId}")]
        public SonucModel YorumSil(int yorumId)
        {
            Yorum kayit = db.Yorum.Where(s => s.yorumId == yorumId).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı";
                return sonuc;

            }

            db.Yorum.Remove(kayit);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "Yorum Silindi.";


            return sonuc;

        }


            #endregion
        }
}
