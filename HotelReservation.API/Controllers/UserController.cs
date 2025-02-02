﻿using HotelReservation.Application.Contracts.Persistence;
using HotelReservation.Application.DTO.User;
using HotelReservation.Application.DTO.User.Login;
using HotelReservation.Application.DTO.User.Registration;
using HotelReservation.Application.DTO.User.Update;
using HotelReservation.Application.Result;
using HotelReservation.Application.UseCases.AppUser;
using HotelReservation.Domain.Repository.DataManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace HotelReservation.API.Controllers
{
    [ApiController]
    [Route("HotelReservationApi/[action]")]
    public class UserController : Controller/*Controller*/
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
          
        }

        [HttpGet("/Users")]
        [ProducesResponseType(typeof(ApiResult<List<UserDTO>>),StatusCodes.Status200OK)]
        public async Task<IActionResult>GetAllUsers()/*Action*/
        {
            var users = await _userService.GetAllUsers();

            return StatusCode((int)users.StatusCode, users);
        }


        [HttpPost("/User")]
        [ProducesResponseType(typeof(ApiResult<UserDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddUser(UserRegistrationRequestDTO userRegistrationRequestDTO)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            var user = await _userService.AddUser(userRegistrationRequestDTO);
            return Ok(user);
        }
        
        [HttpPut("/User")]
        [ProducesResponseType(typeof(ApiResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUser(UserUpdateRequestDTO userUpdateRequestDTO)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            var result = await _userService.UpdateUser(userUpdateRequestDTO);
            return StatusCode((int)result.StatusCode, result);
        }

        [HttpDelete("/User/{userGUID}")]
        [ProducesResponseType(typeof(ApiResult<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteUser(Guid userGUID)
        {
           var result =  await _userService.DeleteUser(userGUID);

            return StatusCode((int)result.StatusCode, result);
        }
         
        [HttpGet("/User/{userGUID}")]
        [ProducesResponseType(typeof(ApiResult<UserDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUser(Guid userGUID)
        {
            var result =  await _userService.GetUserByGuid(userGUID);

            return StatusCode((int)result.StatusCode, result);
        } 
        
        [HttpPost("/Login")]
        [ProducesResponseType(typeof(ApiResult<LoginResponseDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> LoginUser([FromBody]LoginRequestDTO loginRequest)
        {
           var result =  await _userService.LoginAsync(loginRequest);

            return StatusCode((int)result.StatusCode, result);
        }


    }
}
