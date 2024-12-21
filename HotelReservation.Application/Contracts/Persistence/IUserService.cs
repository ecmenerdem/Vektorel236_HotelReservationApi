

using HotelReservation.Application.Result;

namespace HotelReservation.Application.Contracts.Persistence
{
    public interface IUserService
    {
        Task<UserDTO> GetUserByID(int id);
        Task<UserDTO> GetUserByEmail(string email);
        Task<UserDTO> GetUserByUsername(string userName);
        Task<ApiResult<UserDTO>> GetUserByGuid(Guid guid);
        Task<ApiResult<IEnumerable<UserDTO>>> GetAllUsers();
        Task<bool> UpdateUser(UserUpdateRequestDTO userUpdateDTO);
        Task<ApiResult<bool>> DeleteUser(Guid guid);
        Task<ApiResult<UserDTO>> AddUser(UserRegistrationRequestDTO user);
        Task<IEnumerable<UserDTO>> GetDeletedUsers();
        Task<ApiResult<LoginResponseDTO>> LoginAsync(LoginRequestDTO loginRequestDTO);


    }
}
