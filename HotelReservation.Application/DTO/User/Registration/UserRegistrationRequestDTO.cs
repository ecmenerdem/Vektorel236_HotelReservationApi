using System.ComponentModel.DataAnnotations;

namespace HotelReservation.Application.DTO.User.Registration
{
    public class UserRegistrationRequestDTO
    {
        //[Required(ErrorMessage ="Ad Zorunlu Olarak Girilmelidir")]
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string EPosta { get; set; }
        public string TelNo { get; set; }
    }
}
