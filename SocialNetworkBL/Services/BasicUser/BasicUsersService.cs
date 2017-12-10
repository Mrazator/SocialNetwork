using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure;
using Infrastructure.Query;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.QueryObjects.Common;
using SocialNetworkBL.Services.Common;

namespace SocialNetworkBL.Services.BasicUser
{
    public class BasicUsersService : CrudQueryServiceBase<SocialNetwork.Entities.User, BasicUserDto, UserFilterDto>, IBasicUsersService
    {
        public BasicUsersService(IMapper mapper,
            IRepository<SocialNetwork.Entities.User> repository,
            QueryObjectBase<BasicUserDto, SocialNetwork.Entities.User, UserFilterDto, IQuery<SocialNetwork.Entities.User>> query)
            : base(mapper, repository, query)
        {
        }

        public async Task<BasicUserDto> GetUserByNickName(string nickName)
        {
            var query = await Query.ExecuteQuery(new UserFilterDto()
            {
                NickName = nickName
            });

            return query?.Items?.SingleOrDefault();
        }

        public async Task<IEnumerable<BasicUserDto>> GetUsersContainingSubNameAsync(string subname)
        {
            var queryResult = await Query.ExecuteQuery(new UserFilterDto() { SubName = subname });
            return queryResult?.Items;
        }

        public async Task<QueryResultDto<BasicUserDto, UserFilterDto>> GetUsersQueryContainingSubNameAsync(string subName)
        {
            return await Query.ExecuteQuery(new UserFilterDto() { SubName = subName });
        }
    }
}
