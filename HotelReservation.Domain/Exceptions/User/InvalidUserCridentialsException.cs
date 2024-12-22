using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Domain.Exceptions.User
{
    public class InvalidUserCridentialsException : Exception
    {
        public InvalidUserCridentialsException() : base("Kullanıcı adı veya şifre yanlış.")
        {
            this.Data["StatusCode"] = HttpStatusCode.Unauthorized;
        }
    }
}
