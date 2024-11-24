using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Domain.Exceptions
{
    public class InvalidUserCridentialsException:Exception
    {
        public InvalidUserCridentialsException():base("Kullanıcı adı veya şifre yanlış.")
        {
            
        }
    }
}
