using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Services.Common;

namespace SocialNetworkBL.Services.UserGroups
{
    public interface IUserGroupService : IService<UserGroupDto, UserGroupFilterDto>
    {
        Task<IList<GroupDto>> GetGroupsByUserIdAsync(int userId);
    }
}