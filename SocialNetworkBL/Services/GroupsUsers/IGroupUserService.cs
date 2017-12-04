using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Services.Common;
using System.Threading.Tasks;

namespace SocialNetworkBL.Services.GroupsUsers
{
    public interface IGroupUserService : IService<GroupUserDto, GroupUserFilterDto>
    {
        Task<GroupUserDto> GetGroupUserAsync(int groupId, int userId);

        Task<int> AddUserToGroupAsync(AddUserToGroupDto userToGroupDto, bool isAdmin);
    }
}
