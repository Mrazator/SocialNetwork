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
using SocialNetworkDAL.Entities;

namespace SocialNetworkBL.Services.Friendships
{
    public class FriendshipService : 
        CrudQueryServiceBase<Friendship, FriendshipDto, FriendshipFilterDto>,
        IFriendshipService
    {
        public FriendshipService(IMapper mapper, IRepository<Friendship> repository,
            QueryObjectBase<FriendshipDto, Friendship, FriendshipFilterDto, IQuery<Friendship>> query)
            : base(mapper, repository, query)
        {
        }

        public async Task<IEnumerable<BasicUserDto>> GetFriendsByUserIdAsync(int userId, bool? isAccepted)
        {
            var queryResult =
                await Query.ExecuteQuery(new FriendshipFilterDto() {UserId = userId, IsAccepted = isAccepted});
            return queryResult?.Items.Select(x => x.User1Id == userId ? x.User2 : x.User1);
        }

        public async Task<IEnumerable<FriendshipDto>> GetFriendshipsByUserIdAsync(int userId, bool? isAccepted = false)
        {
            var queryResult = await Query.ExecuteQuery(new FriendshipFilterDto { UserId = userId, IsAccepted = isAccepted});
            return queryResult?.Items;
        }
    }
}