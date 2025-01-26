using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Application.DTO.User.Update
{
    public class UserUpdateRequestDTO
    {
        public Guid Guid { get; set; }

        //[Required(ErrorMessage ="Ad alanı Zorunlu Olarak Doldurulmalıdır")]
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Sifre { get; set; }
        public string EPosta { get; set; }
        public string TelNo { get; set; }
        public Guid? GroupGUID { get; set; }

    }
}
