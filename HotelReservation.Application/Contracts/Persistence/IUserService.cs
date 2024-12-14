

namespace HotelReservation.Application.Contracts.Persistence
{
    public interface IUserService
    {
        Task<UserDTO> GetUserByID(int id);
        Task<UserDTO> GetUserByEmail(string email);
        Task<UserDTO> GetUserByUsername(string userName);
        Task<UserDTO> GetUserByGuid(Guid guid);
        Task<IEnumerable<UserDTO>> GetAllUsers();
        Task<bool> UpdateUser(UserUpdateRequestDTO userUpdateDTO);
        Task<bool> DeleteUser(int id);
        Task<UserDTO> AddUser(UserRegistrationRequestDTO user);
        Task<IEnumerable<UserDTO>> GetDeletedUsers();
        Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO);


    }
}
