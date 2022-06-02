using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final.ViewModel
{
    public class HaberModel
    {
        public int haberId { get; set; }



        public string haberBaslik { get; set; }
        public string haberDetay { get; set; }
        public DateTime haberTarih { get; set; }
        public int haberKategoriId { get; set; }
        public string kategoriAdi { get; set; }
        public int haberUyeId { get; set; }
        public string uyeKadi { get; set; }
        public int haberOkuma { get; set; }
    }
}