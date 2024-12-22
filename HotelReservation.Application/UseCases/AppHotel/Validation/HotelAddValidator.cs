using HotelReservation.Application.DTO.Hotel.Add;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Application.UseCases.AppHotel.Validation
{
    public class HotelAddValidator:AbstractValidator<HotelAddRequestDTO>
    {
        public HotelAddValidator()
        {
            RuleFor(q => q.Ad).NotEmpty().WithMessage("Otel Adı Boş Olamaz");
            RuleFor(q => q.EPosta).NotEmpty().WithMessage("Otel E-Posta Boş Olamaz").EmailAddress().WithMessage("Geçerli Bir E-Posta Adresi Giriniz");
            RuleFor(q => q.Sehir).NotEmpty().WithMessage("Şehir Boş Olamaz");
            RuleFor(q => q.Adres).NotEmpty().WithMessage("Otel Adresi Boş Olamaz");
            RuleFor(q => q.Aciklama).NotEmpty().WithMessage("Otel Açıklaması Boş Olamaz");
            RuleFor(q => q.Tel).NotEmpty().WithMessage("Otel Telefon Numarası Boş Olamaz");
        }
    }
}
