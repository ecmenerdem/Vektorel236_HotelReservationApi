using FluentValidation.Results;
using HotelReservation.Application.Contracts.Persistence;
using HotelReservation.Application.DTO.User;
using HotelReservation.Application.UseCases.User.Validation;
using HotelReservation.Domain.Entity;
using HotelReservation.Domain.Exceptions;
using HotelReservation.Domain.Repository;
using HotelReservation.Domain.Repository.DataManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            LoginValidator loginValidator = new LoginValidator();

            var validationResult  = loginValidator.Validate(loginRequestDTO);

            if (!validationResult.IsValid)
            {
                List<ValidationFailure> errors = new List<ValidationFailure>();

                foreach (var item in validationResult.Errors)
                {
                    errors.Add(new() { ErrorMessage=item.ErrorMessage});
                }

                throw new FluentValidation.ValidationException(errors);

            }


           

            Domain.Entity.User user = new Domain.Entity.User();
            user.Username = loginRequestDTO.Username;
            user.Password = loginRequestDTO.Password;

           var loginUser = await _uow.UserRepository.LoginAsync(user);

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
