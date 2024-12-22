using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Domain.Exceptions.User
{
    public class InvalidUserEMailException : Exception
    {
        public InvalidUserEMailException() : base("Girmiş olduğunuz e-posta adresi daha önce kullanılmıştır. Lütfen başka bir e-posta adresi yazınız")
        {
            this.Data["StatusCode"] = HttpStatusCode.BadRequest;
        }

        public InvalidUserEMailException(string message) : base(message)
        {

        }
    }
}
