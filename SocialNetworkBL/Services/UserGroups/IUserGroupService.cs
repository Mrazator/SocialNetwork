using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBL.Services.UserGroups
{
    public interface IUserGroupService : IService<UserGroupDto, UserGroupFilterDto>
    {
        Task<IList<GroupDto>> GetGroupsByUserIdAsync(int userId);
    }
}
