using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Services.Common;

namespace SocialNetworkBL.Services.GroupsUsers
{
    public interface IGetUserGroupsService : IService<GetUserGroupsDto, GetUserGroupsFilterDto>
    {
        Task<IList<GetUserGroupsDto>> GetGroupsByUserIdAsync(int userId, bool? isAccepted);
    }
}