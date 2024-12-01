using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HotelReservation.Application.DTO.User.Login
{
    public class LoginResponseDTO
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string KullaniciAdi { get; set; }

        public string Token { get; set; }

        public string AdSoyad
        {

            get
            {

                return Ad + " " + Soyad;

            }



        }

    }
}
