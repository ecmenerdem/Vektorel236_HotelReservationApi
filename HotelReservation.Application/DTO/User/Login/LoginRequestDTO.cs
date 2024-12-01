using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Application.DTO.User.Login
{
    public class LoginRequestDTO
    {
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
    }
}
