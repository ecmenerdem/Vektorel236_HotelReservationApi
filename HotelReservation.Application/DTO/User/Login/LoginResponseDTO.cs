
namespace HotelReservation.Application.DTO.User.Login
{
    public class LoginResponseDTO
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string KullaniciAdi { get; set; }

        public string Token { get; set; }

        public string AdSoyad
        {

            get
            {

                return Ad + " " + Soyad;

            }



        }

    }
}
