namespace HotelReservation.Application.Contracts.Persistence
{
    public interface IUserService
    {
        Task<User> GetUserByID(int id);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserByUsername(string userName);
        Task<User> GetUserByGuid(string email);
        Task<IEnumerable<User>> GetAllUsers();
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
        Task<User> AddUser(UserRegistrationRequestDTO user);
        Task<IEnumerable<User>> GetDeletedUsers();
        Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO);


    }
}
