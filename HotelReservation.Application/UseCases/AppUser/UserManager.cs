using HotelReservation.Application.Result;
using System.Net;

namespace HotelReservation.Application.UseCases.AppUser
{
    public class UserManager : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IGenericValidator _validator;
        private readonly IMapper _mapper;

        public UserManager(IUnitOfWork uow, IGenericValidator validator, IMapper mapper)
        {
            _uow = uow;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<ApiResult<UserDTO>> AddUser(UserRegistrationRequestDTO userRegistrationRequestDTO)
        {

            await _validator.ValidateAsync(userRegistrationRequestDTO, typeof(UserRegistrationValidator));


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
            User user = _mapper.Map<User>(userRegistrationRequestDTO);
            await _uow.UserRepository.AddAsync(user);
            await _uow.SaveChangeAsync();

            return ApiResult<UserDTO>.SuccesResult(_mapper.Map<UserDTO>(user),"Kullanıcı Oluşturuldu");

        }

        public Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            var users = await _uow.UserRepository.GetAllAsync();

            //List<UserDTO> userDTOList = new List<UserDTO>();

            //foreach (var user in users) {

            //    userDTOList.Add(_mapper.Map<UserDTO>(user));
            //}
            //return userDTOList;

            var userDTOList = users.Select(user => _mapper.Map<UserDTO>(user)).ToList();

            if (userDTOList.Any())
            {
                return ApiResult<IEnumerable<UserDTO>>.SuccesResult(userDTOList);
            }

            return ApiResult<IEnumerable<UserDTO>>.SuccesResult(userDTOList, "Kullanıcılar Bulunamadı", HttpStatusCode.NotFound);

        }

        public async Task<IEnumerable<UserDTO>> GetDeletedUsers()
        {
            var users = await _uow.UserRepository.GetDeletedUsers();

            return users.Select(user => _mapper.Map<UserDTO>(user));
        }

        public async Task<UserDTO> GetUserByEmail(string email)
        {
            var user =  await _uow.UserRepository.GetAsync(q => q.Email == email);

            UserDTO userDTO = _mapper.Map<UserDTO>(user);

            return userDTO;
        }

        public async Task<UserDTO> GetUserByGuid(Guid guid)
        {
            return _mapper.Map<UserDTO>(await _uow.UserRepository.GetAsync(q => q.GUID == guid));
        }

        public Task<UserDTO> GetUserByID(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> GetUserByUsername(string userName)
        {
            var user =  await _uow.UserRepository.GetAsync(q => q.Username == userName);

            UserDTO userDTO = _mapper.Map<UserDTO>(user);

            return userDTO;
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO)
        {


            await _validator.ValidateAsync(loginRequestDTO, typeof(LoginValidator));

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

            LoginResponseDTO loginResponseDTO = _mapper.Map<LoginResponseDTO>(loginUser);

            if (loginUser is null)
            {
                throw new InvalidUserCridentialsException();
            }

            return loginResponseDTO;
        }

        public async Task<bool> UpdateUser(UserUpdateRequestDTO userUpdateDTO)
        {
            await _validator.ValidateAsync(userUpdateDTO, typeof(UserUpdateValidator));

            var existUser = await _uow.UserRepository.GetAsync(q => q.GUID == userUpdateDTO.Guid);
            if (existUser is not null)
            {
                existUser = _mapper.Map<User>(userUpdateDTO);
            }
            _uow.UserRepository.Update(existUser);
            return true;
        }
    }
}
