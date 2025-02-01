using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.WebHelper.DTO.Hotel
{
    public class HotelDetailDTO
    {
        public Guid Guid { get; set; }
        public string Ad { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string Aciklama { get; set; }
        public string Tel { get; set; }
        public string EPosta { get; set; }
        public string FeaturedImage { get; set; }

    }
}
