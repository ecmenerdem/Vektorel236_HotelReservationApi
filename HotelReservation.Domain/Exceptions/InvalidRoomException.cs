using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Domain.Exceptions
{
    public class InvalidRoomException:Exception
    {
        public InvalidRoomException():base("Oda satışa uygun değil")
        {
            
        }
        public InvalidRoomException(int roomId, string checkInDate, string checkOutDate):base($"{roomId} numaralı oda {checkInDate} ile {checkOutDate} tarihleri arasında müsait değildir. Lütfen tarihi veya oda numarasını değiştirip tekrar deneyiniz.")
        {
            
        }
    }
}
