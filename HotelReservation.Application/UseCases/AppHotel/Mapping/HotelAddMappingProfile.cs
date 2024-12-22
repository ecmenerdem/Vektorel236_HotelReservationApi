using HotelReservation.Application.DTO.Hotel.Add;

namespace HotelReservation.Application.UseCases.AppHotel.Mapping
{
    public class HotelAddMappingProfile:Profile
    {
        public HotelAddMappingProfile()
        {
            CreateMap<Hotel, HotelAddRequestDTO>()
               
                .ForMember(dest => dest.EPosta, opt => opt.MapFrom(src => src.EMail))
                .ForMember(dest => dest.Sehir, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.Adres, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Aciklama, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Ad, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Tel, opt => opt.MapFrom(src => src.PhoneNumber))
                .ReverseMap();
        }
    }
}
