using HotelReservation.Application.DTO.Hotel.Update;

namespace HotelReservation.Application.UseCases.AppHotel.Validation
{
    public class HotelUpdateValidator:AbstractValidator<HotelUpdateRequestDTO>
    {
        public HotelUpdateValidator()
        {
            RuleFor(q => q.Guid).NotEmpty().WithMessage("Geçerli Bir Otel Giriniz");
            RuleFor(q => q.Ad).NotEmpty().WithMessage("Otel Adı Boş Olamaz");
            RuleFor(q => q.EPosta).NotEmpty().WithMessage("Otel E-Posta Boş Olamaz").EmailAddress().WithMessage("Geçerli Bir E-Posta Adresi Giriniz");
            RuleFor(q => q.Sehir).NotEmpty().WithMessage("Şehir Boş Olamaz");
            RuleFor(q => q.Adres).NotEmpty().WithMessage("Otel Adresi Boş Olamaz");
            RuleFor(q => q.Aciklama).NotEmpty().WithMessage("Otel Açıklaması Boş Olamaz");
            RuleFor(q => q.Tel).NotEmpty().WithMessage("Otel Telefon Numarası Boş Olamaz");
        }
    }
}
