namespace HotelReservation.Domain.Exceptions
{
    public class TokenNotFoundException:Exception
    {
        public TokenNotFoundException():base("Token Bilgisi Gelmedi")
        {
            
        }
    }
}
