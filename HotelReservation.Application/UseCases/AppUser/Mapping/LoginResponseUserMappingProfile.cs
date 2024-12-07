using AutoMapper;
using HotelReservation.Application.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Application.UseCases.AppUser.Mapping
{
    public class LoginResponseUserMappingProfile:Profile
    {
        public LoginResponseUserMappingProfile()
        {
            CreateMap<User, LoginResponseDTO>()
               .ForMember(dest => dest.Ad, opt => opt.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.Soyad, opt => opt.MapFrom(src => src.LastName))
               .ForMember(dest => dest.KullaniciAdi, opt => opt.MapFrom(src => src.Username))
             .ReverseMap();
        }
    }
}
