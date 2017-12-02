using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.UnitOfWork;
using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Facades.Common;
using SocialNetworkBL.Services.Common;
using SocialNetworkBL.Services.GroupUsers;
using SocialNetworkBL.Services.UserGroups;

namespace SocialNetworkBL.Facades
{
    public class GroupUserFacade : FacadeBase<GroupUser, GroupUserDto, GroupUserFilterDto>
    {
        private readonly IGroupUserService _groupUserService;
        private readonly IUserGroupService _userGroupService;

        public GroupUserFacade(
            IUnitOfWorkProvider unitOfWorkProvider,
            CrudQueryServiceBase<GroupUser, GroupUserDto, GroupUserFilterDto> service,
            IGroupUserService groupUserService,
            IUserGroupService userGroupService
        ) : base(unitOfWorkProvider, service)
        {
            _groupUserService = groupUserService;
            _userGroupService = userGroupService;
        }

        public async Task<IList<GroupDto>> GetGroupsByUserIdAsync(int userId)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await _userGroupService.GetGroupsByUserIdAsync(userId);
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