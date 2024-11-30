using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Domain.Exceptions
{
    public class InvalidEMailException:Exception
    {
        public InvalidEMailException():base("Girmiş olduğunuz e-posta adresi daha önce kullanılmıştır. Lütfen başka bir e-posta adresi yazınız")
        {
            
        }

        public InvalidEMailException(string message):base(message)
        {
            
        }
    }
}
