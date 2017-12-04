using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Services.Common;

namespace SocialNetworkBL.Services.Groups
{
    public interface IGroupService : IService<GroupDto, GroupFilterDto>
    {
        Task<IList<GroupDto>> GetGroupsContainingSubNameAsync(string subName);

        Task<int> CreateGroupAsync(GroupCreateDto groupDto);
    }
}