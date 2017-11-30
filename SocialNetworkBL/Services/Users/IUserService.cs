using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBL.Services.Users
{
    public interface IUserService : IService<UserDto, UserFilterDto>
    {
        Task<IEnumerable<UserDto>> GetUsersContainingSubNameAsync(string subName);

        Task<UserDto> GetByNickNameAsync(string nickName);

        Task<int> RegisterUserAsync(UserCreateDto userDto);

        Task<bool> AuthorizeUserAsync(string nickName, string password);
    }
}
