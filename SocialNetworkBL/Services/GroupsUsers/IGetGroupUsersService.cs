using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Services.Common;
using SocialNetworkBL.DataTransferObjects.GroupProfileDtos;

namespace SocialNetworkBL.Services.GroupsUsers
{
    public interface IGetGroupUsersService : IService<GetGroupUsersDto, GetGroupUsersFilterDto>
    {
        Task<IList<GroupProfileUserDto>> GetGroupProfileUsersAsync(int groupId);
        Task<IEnumerable<GetGroupUsersDto>> GetGroupUsersAsync(int groupId);
    }
}