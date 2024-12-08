namespace HotelReservation.Application.UseCases.AppUser.Mapping
{
    public class UserMappingProfile:Profile
    {
        public UserMappingProfile()
        {
           CreateMap<User,UserDTO>()
                .ForMember(dest=>dest.Guid,opt=>opt.MapFrom(src=>src.GUID))
                .ForMember(dest=>dest.FirstName,opt=>opt.MapFrom(src=>src.FirstName))
                .ForMember(dest=>dest.LastName,opt=>opt.MapFrom(src=>src.LastName))
                .ForMember(dest=>dest.Username,opt=>opt.MapFrom(src=>src.Username))
                .ForMember(dest=>dest.Email,opt=>opt.MapFrom(src=>src.Email))
                .ForMember(dest=>dest.PhoneNumber,opt=>opt.MapFrom(src=>src.PhoneNumber)).ReverseMap();


        }
    }
}
