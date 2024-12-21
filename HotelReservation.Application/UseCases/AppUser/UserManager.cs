using HotelReservation.Application.Contracts.Security;
using HotelReservation.Application.Result;
using System.Net;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HotelReservation.Application.UseCases.AppUser
{
    public class UserManager : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IGenericValidator _validator;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public UserManager(IUnitOfWork uow, IGenericValidator validator, IMapper mapper, ITokenService tokenService)
        {
            _uow = uow;
            _validator = validator;
            _mapper = mapper;
            _tokenService = tokenService;
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

            return ApiResult<UserDTO>.SuccesResult(_mapper.Map<UserDTO>(user),HttpStatusCode.OK,"Kullanıcı Oluşturuldu");

        }

        public async Task<ApiResult<bool>> DeleteUser(Guid guid)
        {
            var user = await _uow.UserRepository.GetAsync(q => q.GUID == guid);

            if (user == null) {
                var error = new ErrorResult(new List<string> { "Kullanıcı Bulunamadı" });

                return ApiResult<bool>.FailureResult(error,HttpStatusCode.NotFound);

            }

            user.IsActive = false;
            user.IsDeleted = true;
            _uow.UserRepository.Update(user);
            await _uow.SaveChangeAsync();

            return ApiResult<bool>.SuccesResult(true,HttpStatusCode.OK);

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

            return ApiResult<IEnumerable<UserDTO>>.SuccesResult(userDTOList, HttpStatusCode.NotFound, "Kullanıcılar Bulunamadı" );

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

        public async Task<ApiResult<UserDTO>> GetUserByGuid(Guid guid)
        {
            var user = await _uow.UserRepository.GetAsync(q => q.GUID == guid);

            if (user is null)
            {
                var error = new ErrorResult(new List<string> { "Kullanıcı Bulunamadı" });

                return ApiResult<UserDTO>.FailureResult(error, HttpStatusCode.NotFound);

            }

            return ApiResult<UserDTO>.SuccesResult(_mapper.Map<UserDTO>(user), HttpStatusCode.OK);
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

        public async Task<ApiResult<LoginResponseDTO>> LoginAsync(LoginRequestDTO loginRequestDTO)
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
            if (loginUser is null)
            {
                var error = new ErrorResult(new List<string> { "Kullanıcı Adı Veya Şifre Yanlış" });

                return ApiResult<LoginResponseDTO>.FailureResult(error, HttpStatusCode.Unauthorized);

                //throw new InvalidUserCridentialsException();
            }

            var claims = new List<Claim>
            {
                new Claim("KullaniciGUID",loginUser.GUID.ToString()),
                new Claim("KullaniciAdi",loginUser.Username),
                new Claim("AdSoyad",loginUser.FullName),
                new Claim("EMail",loginUser.Email),
                new Claim("Phone",loginUser.PhoneNumber)

            };

            var token = _tokenService.GenerateToken(claims);
            var loginUserDTO = _mapper.Map<LoginResponseDTO>(loginUser);
            loginUserDTO.Token=token;
            return ApiResult<LoginResponseDTO>.SuccesResult(loginUserDTO);
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
