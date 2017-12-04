using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Services.Common;

namespace SocialNetworkBL.Services.GroupsUsers
{
    public interface IGetGroupUsersService : IService<GetGroupUsersDto, GetGroupUsersFilterDto>
    {
        Task<IList<UserDto>> GetUsersByGroupIdAsync(int groupId);
    }
}