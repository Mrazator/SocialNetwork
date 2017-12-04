using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.UnitOfWork;
using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Facades.Common;
using SocialNetworkBL.Services.Common;
using SocialNetworkBL.Services.Groups;
using SocialNetworkBL.Services.GroupsUsers;

namespace SocialNetworkBL.Facades
{
    public class GroupFacade : FacadeBase<Group, GroupDto, GroupFilterDto>
    {
        private readonly IGroupService _groupService;
        private readonly IGetGroupUsersService _getGroupUsersService;

        public GroupFacade(
            IUnitOfWorkProvider unitOfWorkProvider,
            CrudQueryServiceBase<Group, GroupDto, GroupFilterDto> service,
            IGroupService groupService,
            IGetGroupUsersService getGroupUsersService
        ) : base(unitOfWorkProvider, service)
        {
            _groupService = groupService;
        }

        public async Task<IList<GroupDto>> GetGroupsContainingSubNameAsync(string subName)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await _groupService.GetGroupsContainingSubNameAsync(subName);
            }
        }

        public async Task<IList<UserDto>> GetUsersByGroupIdAsync(int groupId)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await _getGroupUsersService.GetUsersByGroupIdAsync(groupId);
            }
        }
    }
}