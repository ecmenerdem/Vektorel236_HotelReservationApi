using HotelReservation.Application.Contracts.Security;
using HotelReservation.Application.DTO.UserGroup;
using HotelReservation.Application.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Application.UseCases.AppUserGroup
{
    public class UserGroupManager : IUserGroupService
    {
        private readonly IUnitOfWork _uow;
        private readonly IGenericValidator _validator;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public UserGroupManager(IUnitOfWork uow, IGenericValidator validator, IMapper mapper, ITokenService tokenService)
        {
            _uow = uow;
            _validator = validator;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<ApiResult<IEnumerable<UserGroupDTO>>> GetAllGroups()
        {
            var userGroups = await _uow.UserGroupRepository.GetAllAsync();

           

            var userGroupDTOList = userGroups.Select(usergroup => _mapper.Map<UserGroupDTO>(usergroup)).ToList();

            if (userGroupDTOList.Any())
            {
                return ApiResult<IEnumerable<UserGroupDTO>>.SuccesResult(userGroupDTOList);
            }

            return ApiResult<IEnumerable<UserGroupDTO>>.SuccesResult(userGroupDTOList, HttpStatusCode.NotFound, "Grup Bulunamadı");
        }
    }
}
