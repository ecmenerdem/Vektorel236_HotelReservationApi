using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Domain.Exceptions.User
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string username) : base($"'{username}' kullanıcı adına sahip bir kullanıcı bulunamadı.")
        {
            this.Data["StatusCode"] = HttpStatusCode.NotFound;
        }
        public UserNotFoundException() : base($"Kullanıcı bulunamadı.")
        {
            this.Data["StatusCode"]=HttpStatusCode.NotFound;
        }

        public UserNotFoundException(int id) : base($"ID si {id} olan kullanıcı bulunamadı.")
        {
            this.Data["StatusCode"] = HttpStatusCode.NotFound;
        }
    }
}
