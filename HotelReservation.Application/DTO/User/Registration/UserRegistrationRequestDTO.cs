using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Application.DTO.User.Registration
{
    public class UserRegistrationRequestDTO
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string EPosta { get; set; }
        public string TelNo { get; set; }
    }
}
