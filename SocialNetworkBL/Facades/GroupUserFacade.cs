using Infrastructure.UnitOfWork;
using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Facades.Common;
using SocialNetworkBL.Services.Common;
using SocialNetworkBL.Services.GroupUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupUser = SocialNetwork.Entities.GroupUser;

namespace SocialNetworkBL.Facades
{
    public class GroupUserFacade : FacadeBase<GroupUser, GroupUserDto, GroupUserFilterDto>
    {
        private readonly IGroupUserService _groupUserService;

        public GroupUserFacade(
            IUnitOfWorkProvider unitOfWorkProvider,
            CrudQueryServiceBase<GroupUser, GroupUserDto, GroupUserFilterDto> service,
            IGroupUserService groupUserService
            ) : base(unitOfWorkProvider, service)
        {
            _groupUserService = groupUserService;
        }

        public async Task<IList<GroupDto>> GetGroupsByUserIdAsync(int userId)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await _groupUserService.GetGroupsByUserIdAsync(userId);
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
