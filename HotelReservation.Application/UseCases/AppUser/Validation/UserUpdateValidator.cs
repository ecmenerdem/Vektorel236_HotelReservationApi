using HotelReservation.Application.DTO.User.Update;

namespace HotelReservation.Application.UseCases.AppUser.Validation
{
    public class UserUpdateValidator : AbstractValidator<UserUpdateRequestDTO>
    {
        public UserUpdateValidator()
        {
            RuleFor(q => q.Ad).NotEmpty().WithMessage("Ad Boş Olamaz");
            RuleFor(q => q.Soyad).NotEmpty().WithMessage("Soyad Boş Olamaz");
            RuleFor(q => q.Sifre).NotEmpty().WithMessage("Şifre Boş Olamaz");
            RuleFor(q => q.EPosta).NotEmpty().WithMessage("E-Posta Boş Olamaz");
            RuleFor(q => q.TelNo).NotEmpty().WithMessage("Telefon No Boş Olamaz");
        }
    }
}
