using HotelReservation.Application.DTO.User.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Application.UseCases.AppUser.Mapping
{
    public class UserUpdateRequestMappingProfile:Profile
    {
        public UserUpdateRequestMappingProfile()
        {
            CreateMap<UserUpdateRequestDTO, User>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Ad))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Soyad))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Sifre))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.EPosta))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.TelNo)) 
                .ReverseMap();
        }
    }
}
