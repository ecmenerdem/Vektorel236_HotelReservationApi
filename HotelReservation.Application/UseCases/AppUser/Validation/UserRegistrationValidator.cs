﻿namespace HotelReservation.Application.UseCases.AppUser.Validation
{
    public class UserRegistrationValidator : AbstractValidator<UserRegistrationRequestDTO>
    {
        public UserRegistrationValidator()
        {
            RuleFor(q => q.Ad).NotEmpty().WithMessage("Ad Boş Olamaz");
            RuleFor(q => q.Soyad).NotEmpty().WithMessage("Soyad Boş Olamaz");
            RuleFor(q => q.KullaniciAdi).NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz");

            RuleFor(q => q.KullaniciAdi.Length).GreaterThan(2).When(q=>!string.IsNullOrEmpty(q.KullaniciAdi)).WithMessage("Kullanıcı Adı En Az 3 Karakter Olmalıdır.");

            RuleFor(q => q.Sifre).NotEmpty().WithMessage("Şifre Boş Olamaz");
            RuleFor(q => q.EPosta).NotEmpty().WithMessage("E-Posta Boş Olamaz");
            RuleFor(q => q.TelNo).NotEmpty().WithMessage("Telefon No Boş Olamaz");
        }
    }
}
