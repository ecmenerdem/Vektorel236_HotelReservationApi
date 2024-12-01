using FluentValidation;
using HotelReservation.Application.DTO.User.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Application.UseCases.User.Validation
{
    public class LoginValidator:AbstractValidator<LoginRequestDTO>
    {
        public LoginValidator()
        {
           RuleFor(x => x.KullaniciAdi).NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz");
           RuleFor(q=>q.Sifre).NotEmpty().WithMessage("Şifre Boş Olamaz");
        }
    }
}
