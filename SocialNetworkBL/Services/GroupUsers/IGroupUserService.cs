using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Services.Common;

namespace SocialNetworkBL.Services.GroupUsers
{
    public interface IGroupUserService : IService<GroupUserDto, GroupUserFilterDto>
    {
        //Task<IList<GroupDto>> GetGroupsByUserIdAsync(int userId);

        Task<IList<UserDto>> GetUsersByGroupIdAsync(int groupId);
    }
}