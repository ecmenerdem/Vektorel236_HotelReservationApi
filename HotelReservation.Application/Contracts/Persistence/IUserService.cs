using HotelReservation.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        Task<User> AddUser(User user);
        Task<IEnumerable<User>> GetDeletedUsers();


    }
}
