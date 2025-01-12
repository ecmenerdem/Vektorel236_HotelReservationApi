using HotelReservation.Application.Contracts.Persistence;
using HotelReservation.Application.DTO.User;
using HotelReservation.Application.DTO.UserGroup;
using HotelReservation.Application.Result;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.API.Controllers
{
    [ApiController]
    [Route("HotelReservationApi/[action]")]

    public class UserGroupController : Controller
    {

        private readonly IUserGroupService _userGroupService;

        public UserGroupController(IUserGroupService userGroupService)
        {
            _userGroupService = userGroupService;
        }

        [HttpGet("/UserGroups")]
        [ProducesResponseType(typeof(ApiResult<List<UserGroupDTO>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllUserGroupsAsync()
        {

            var userGroups = await _userGroupService.GetAllGroups();

            return StatusCode((int)userGroups.StatusCode, userGroups);
        }
    }
}
