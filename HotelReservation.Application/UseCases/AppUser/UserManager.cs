namespace HotelReservation.Application.UseCases.AppUser
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

        public async Task<User> AddUser(UserRegistrationRequestDTO userRegistrationRequestDTO)
        {

            await _genericValidator.ValidateAsync(userRegistrationRequestDTO, typeof(UserRegistrationValidator));











            /*Bu if kullanıcı adı daha önce kayıtlı mı? diye kontrol ediyor*/
            if (await GetUserByUsername(userRegistrationRequestDTO.KullaniciAdi) is not null)
            {
                throw new InvalidUsernameForRegistrationException();

            }

            /*Bu if e-posta daha önce kayıtlı mı? diye kontrol ediyorr*/
            if (await GetUserByEmail(userRegistrationRequestDTO.EPosta) is not null)
            {
                throw new InvalidEMailException();
            }

            User user = new User()
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

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            throw new NotImplementedException();

        }

        public Task<IEnumerable<User>> GetDeletedUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _uow.UserRepository.GetAsync(q => q.Email == email);
        }

        public Task<User> GetUserByGuid(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserByUsername(string userName)
        {
            return await _uow.UserRepository.GetAsync(q => q.Username == userName);
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO)
        {


            await _genericValidator.ValidateAsync(loginRequestDTO, typeof(LoginValidator));

            //LoginValidator loginValidator = new LoginValidator();

            //var validationResult  = loginValidator.Validate(loginRequestDTO);

            //if (!validationResult.IsValid)
            //{
            //    List<ValidationFailure> errors = new List<ValidationFailure>();

            //    foreach (var item in validationResult.Errors)
            //    {
            //        errors.Add(new() { ErrorMessage=item.ErrorMessage});
            //    }

            //    throw new FluentValidation.ValidationException(errors);

            //}




            User user = new User();
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

        public async Task<bool> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
