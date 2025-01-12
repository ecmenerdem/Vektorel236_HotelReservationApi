

using HotelReservation.Application.DTO.UserGroup;
using HotelReservation.Application.Result;

namespace HotelReservation.Application.Contracts.Persistence
{
    public interface IUserGroupService
    {

        Task<ApiResult<IEnumerable<UserGroupDTO>>> GetAllGroups();
      


    }
}
