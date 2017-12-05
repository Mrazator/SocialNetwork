using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure;
using Infrastructure.Query;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.QueryObjects.Common;
using SocialNetworkBL.Services.Common;

namespace SocialNetworkBL.Services.BasicUser
{
    public class BasicUsersService : CrudQueryServiceBase<SocialNetwork.Entities.User, BasicUserDto, UserFilterDto>, IBasicUsersService
    {

        public BasicUsersService(IMapper mapper,
            QueryObjectBase<BasicUserDto, SocialNetwork.Entities.User, UserFilterDto, IQuery<SocialNetwork.Entities.User>> userProfileUsersQueryObject,
            IRepository<SocialNetwork.Entities.User> postRepository)
            : base(mapper, postRepository, userProfileUsersQueryObject)
        {
        }

        public async Task<BasicUserDto> GetUsersByNickName(string nickName)
        {
            var query = await Query.ExecuteQuery(new UserFilterDto()
            {
                NickName = nickName
            });

            return query?.Items?.SingleOrDefault();
        }

        public async Task<IEnumerable<BasicUserDto>> GetUsersContainingSubNameAsync(string subName)
        {
            var queryResult = await Query.ExecuteQuery(new UserFilterDto { SubName = subName });
            return queryResult?.Items;
        }
    }
}
