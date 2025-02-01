using HotelReservation.Application.DTO.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Application.UseCases.AppHotel.Mapping
{
    public class HotelMappingProfile:Profile
    {
        public HotelMappingProfile()
        {
            CreateMap<Hotel, HotelDTO>()
                .ForMember(dest => dest.Guid, opt => opt.MapFrom(src => src.GUID))
                .ForMember(dest => dest.EPosta, opt => opt.MapFrom(src => src.EMail))
                .ForMember(dest => dest.Sehir, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.Adres, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Aciklama, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Ad, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Tel, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.FeaturedImage, opt => opt.MapFrom(src => src.FeaturedImage))
                .ReverseMap();
        }
    }
}
