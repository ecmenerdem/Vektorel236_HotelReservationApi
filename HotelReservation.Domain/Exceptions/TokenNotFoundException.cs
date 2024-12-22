using System.Net;

namespace HotelReservation.Domain.Exceptions
{
    public class TokenNotFoundException:Exception
    {
        public TokenNotFoundException():base("Token Bilgisi Gelmedi")
        {
            this.Data["StatusCode"] = HttpStatusCode.Unauthorized;
        }
    }
}
