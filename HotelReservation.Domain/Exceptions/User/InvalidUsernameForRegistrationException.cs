using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Domain.Exceptions.User
{
    public class InvalidUsernameForRegistrationException : Exception
    {
        public InvalidUsernameForRegistrationException() : base("Girmiş olduğunuz kullanıcı adı ile daha önce kayıt yapılmıştır. Lütfen başka bir kullanıcı adı giriniz.")
        {
            this.Data["StatusCode"] = HttpStatusCode.BadRequest;
        }
    }
}
