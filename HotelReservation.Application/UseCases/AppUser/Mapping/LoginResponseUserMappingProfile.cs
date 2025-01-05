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
               .ForMember(dest => dest.GrupAdi, opt => opt.MapFrom(src => src.Group.Name))
               .ForMember(dest => dest.GrupID, opt => opt.MapFrom(src => src.GroupID))
             .ReverseMap();
        }
    }
}
