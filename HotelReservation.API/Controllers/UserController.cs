using HotelReservation.Application.Contracts.Persistence;
using HotelReservation.Application.DTO.User;
using HotelReservation.Application.DTO.User.Registration;
using HotelReservation.Application.UseCases.AppUser;
using HotelReservation.Domain.Repository.DataManagement;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.API.Controllers
{
    [ApiController]

    public class UserController : Controller/*Controller*/
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("/Users")]
        public async Task<IActionResult>GetAllUsers()/*Action*/
        {
            var users = await _userService.GetAllUsers();

            return Ok(users);
        }


        [HttpPost("/User")]
        public async Task<IActionResult> AddUser(UserRegistrationRequestDTO userRegistrationRequestDTO)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            var user = await _userService.AddUser(userRegistrationRequestDTO);
            return Ok(user);
        }
    }
}
