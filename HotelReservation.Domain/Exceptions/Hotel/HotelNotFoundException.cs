using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Domain.Exceptions.Hotel
{
    public class HotelNotFoundException:Exception
    {
        public HotelNotFoundException():base("Otel Bulunamadı")
        {
            
        }
    }
}
