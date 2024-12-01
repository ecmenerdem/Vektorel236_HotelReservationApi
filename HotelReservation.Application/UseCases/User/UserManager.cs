using FluentValidation.Results;
using HotelReservation.Application.Contracts.Persistence;
using HotelReservation.Application.Contracts.Validation;
using HotelReservation.Application.DTO.User.Login;
using HotelReservation.Application.DTO.User.Registration;
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
        private readonly IGenericValidator _genericValidator;

        public UserManager(IUnitOfWork uow, IGenericValidator genericValidator)
        {
            _uow = uow;
            _genericValidator = genericValidator;
        }

        public async Task<Domain.Entity.User> AddUser(UserRegistrationRequestDTO userRegistrationRequestDTO)
        {

            await _genericValidator.ValidateAsync(userRegistrationRequestDTO, typeof(UserRegistrationValidator));
           

            /*Bu if kullanıcı adı daha önce kayıtlı mı? diye kontrol ediyor*/
            if ((await GetUserByUsername(userRegistrationRequestDTO.KullaniciAdi)) is not null)
            {
                throw new InvalidUsernameForRegistrationException();

            }

            /*Bu if e-posta daha önce kayıtlı mı? diye kontrol ediyorr*/
            if ((await GetUserByEmail(userRegistrationRequestDTO.EPosta)) is not null)
            {
                throw new InvalidEMailException();
            }

            Domain.Entity.User user = new Domain.Entity.User()
            {
                FirstName = userRegistrationRequestDTO.Ad,
                LastName = userRegistrationRequestDTO.Soyad,
                Username = userRegistrationRequestDTO.KullaniciAdi,
                Password = userRegistrationRequestDTO.Sifre,
                PhoneNumber = userRegistrationRequestDTO.TelNo,
                Email = userRegistrationRequestDTO.EPosta
            };


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

            await _genericValidator.ValidateAsync(loginRequestDTO, typeof(LoginValidator));

            Domain.Entity.User user = new Domain.Entity.User();
            user.Username = loginRequestDTO.KullaniciAdi;
            user.Password = loginRequestDTO.Sifre;

           var loginUser = await _uow.UserRepository.LoginAsync(user);

            LoginResponseDTO loginResponseDTO = new()
            {
                Ad = loginUser.FirstName,
                Soyad = loginUser.LastName,
                KullaniciAdi = loginUser.Username,
            };

            if (loginUser is null)
            {
                throw new InvalidUserCridentialsException();
            }

            return loginResponseDTO;
        }

        public async Task<bool> UpdateUser(Domain.Entity.User user)
        {
            throw new NotImplementedException();
        }
    }
}
