using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Query;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Services.Common;

namespace SocialNetworkBL.Services.BasicUser
{
    public interface IBasicUsersService : IService<BasicUserDto, UserFilterDto>
    {
        Task<BasicUserDto> GetUserByNickName(string nickName);
        Task<IEnumerable<BasicUserDto>> GetUsersContainingSubNameAsync(string subname);
        Task<QueryResultDto<BasicUserDto, UserFilterDto>> GetUsersQueryContainingSubNameAsync(string subName);

    }
}