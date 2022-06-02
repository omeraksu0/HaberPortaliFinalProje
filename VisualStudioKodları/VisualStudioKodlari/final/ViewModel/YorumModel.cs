using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace final.ViewModel
{
    public class YorumModel
    {
        public int yorumId { get; set; }
        public string yorumIcerik { get; set; }
        public int uyeId { get; set; }
        public int haberId { get; set; }




        public string kullaniciAdi { get; set; }
        public string haberBaslik { get; set; }
        public System.DateTime tarih { get; set; }

    }
}