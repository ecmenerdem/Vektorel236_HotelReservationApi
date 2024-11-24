using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Domain.Exceptions
{
    public class InvalidReservationDateException:Exception
    {
        public InvalidReservationDateException():base("Giriş tarihi çıkış tarihinden sonra olamaz.")
        {
            
        }
    }
}
