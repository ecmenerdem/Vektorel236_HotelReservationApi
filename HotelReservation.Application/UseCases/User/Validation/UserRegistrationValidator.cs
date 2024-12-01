using FluentValidation;
using HotelReservation.Application.DTO.User.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Application.UseCases.User.Validation
{
    public class UserRegistrationValidator:AbstractValidator<UserRegistrationRequestDTO>
    {
        public UserRegistrationValidator()
        {
            RuleFor(q => q.Ad).NotEmpty().WithMessage("Ad Boş Olamaz");
            RuleFor(q => q.Soyad).NotEmpty().WithMessage("Soyad Boş Olamaz");
            RuleFor(q => q.KullaniciAdi).NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz");

            RuleFor(q => q.KullaniciAdi.Length).GreaterThan(2).WithMessage("Kullanıcı Adı En Az 3 Karakter Olmalıdır.");
           
            RuleFor(q => q.Sifre).NotEmpty().WithMessage("Şifre Boş Olamaz");
            RuleFor(q => q.EPosta).NotEmpty().WithMessage("E-Posta Boş Olamaz");
            RuleFor(q => q.TelNo).NotEmpty().WithMessage("Telefon No Boş Olamaz");
        }
    }
}
