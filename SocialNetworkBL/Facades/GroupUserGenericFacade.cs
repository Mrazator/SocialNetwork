using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.UnitOfWork;
using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Facades.Common;
using SocialNetworkBL.Services.Common;
using SocialNetworkBL.Services.GroupsUsers;
using SocialNetworkBL.Services.Groups;

namespace SocialNetworkBL.Facades
{
    public class GroupUserGenericFacade : GenericFacadeBase<GroupUser, GetGroupUsersDto, GetGroupUsersFilterDto>
    {
        private readonly IGetGroupUsersService _groupUserService;
        private readonly IGetUserGroupsService _userGroupService;

        public GroupUserGenericFacade(
            IUnitOfWorkProvider unitOfWorkProvider,
            CrudQueryServiceBase<GroupUser, GetGroupUsersDto, GetGroupUsersFilterDto> service,
            IGetGroupUsersService groupUserService,
            IGetUserGroupsService userGroupService,
            IGroupService groupService
        ) : base(unitOfWorkProvider, service)
        {
            _groupUserService = groupUserService;
            _userGroupService = userGroupService;
        }

        public async Task<IList<GetUserGroupsDto>> GetGroupsByUserIdAsync(int userId)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await _userGroupService.GetGroupsByUserIdAsync(userId, null);
            }
        }

        public async Task<IList<UserDto>> GetUsersByGroupIdAsync(int groupId)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await _groupUserService.GetUsersByGroupIdAsync(groupId);
            }
        }


    }
}