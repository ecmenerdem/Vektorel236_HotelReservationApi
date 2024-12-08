namespace HotelReservation.Application.UseCases.AppUser.Mapping
{
    public class UserRegistrationRequestProfile : Profile
    {
        public UserRegistrationRequestProfile()
        {
            CreateMap<UserRegistrationRequestDTO, User>()
                 .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Ad))
                  .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Soyad))
                  .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.KullaniciAdi))
                  .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Sifre))
                  .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.EPosta))
                  .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.TelNo)).ReverseMap();
        }
    }
}
