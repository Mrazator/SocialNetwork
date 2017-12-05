using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Services.Common;

namespace SocialNetworkBL.Services.User
{
    public interface IUserService : IService<UserDto, UserFilterDto>
    {
        Task<IEnumerable<UserDto>> GetUsersContainingSubNameAsync(string subName);

        Task<UserDto> GetByNickNameAsync(string nickName);

        Task<int> RegisterUserAsync(UserCreateDto userDto);

        Task<bool> AuthorizeUserAsync(string nickName, string password);
    }
}