using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HotelReservation.WebHelper.DTO.Account
{
    public class WebLoginResponseDTO
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KullaniciAdi { get; set; }

        public string Token { get; set; }

        public string GrupAdi { get; set; }
        public string GrupID { get; set; }
        public string AdSoyad { get; set; }
    }
}
