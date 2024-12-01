using HotelReservation.Application.Contracts.Persistence;
using HotelReservation.Application.DTO.User;
using HotelReservation.Domain.Entity;
using HotelReservation.Domain.Exceptions;
using HotelReservation.Domain.Repository;
using HotelReservation.Domain.Repository.DataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HotelReservation.Application.UseCases.User
{
    public class UserManager : IUserService
    {
        private readonly IUnitOfWork _uow;

        public UserManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Domain.Entity.User> AddUser(Domain.Entity.User user)
        {
            /*Bu if kullanıcı adı daha önce kayıtlı mı? diye kontrol ediyor*/
            if ((await GetUserByUsername(user.Username)) is not null)
            {
                throw new InvalidUsernameForRegistrationException();

            }

            /*Bu if e-posta daha önce kayıtlı mı? diye kontrol ediyorr*/
            if ((await GetUserByEmail(user.Email)) is not null)
            {
                throw new InvalidEMailException();
            }

            await _uow.UserRepository.AddAsync(user);
            await _uow.SaveChangeAsync();
            return user;

        }

        public Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Domain.Entity.User>> GetAllUsers()
        {
            throw new NotImplementedException();

        }

        public Task<IEnumerable<Domain.Entity.User>> GetDeletedUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Entity.User> GetUserByEmail(string email)
        {
            return await _uow.UserRepository.GetAsync(q => q.Email == email);
        }

        public Task<Domain.Entity.User> GetUserByGuid(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entity.User> GetUserByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Entity.User> GetUserByUsername(string userName)
        {
            return await _uow.UserRepository.GetAsync(q => q.Username == userName);
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO)
        {
            var loginUser = await _uow.UserRepository.LoginAsync(loginRequestDTO);

            if (loginUser is null)
            {
                throw new InvalidUserCridentialsException();
            }

            return loginUser;
        }

        public async Task<bool> UpdateUser(Domain.Entity.User user)
        {
            throw new NotImplementedException();
        }
    }
}
