using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure;
using Infrastructure.Query;
using SocialNetworkBL.DataTransferObjects.ChatDtos;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.QueryObjects.Common;
using SocialNetworkBL.Services.Common;
using SocialNetworkDAL.Entities;

namespace SocialNetworkBL.Services.Chat
{
    public class FriendsWithChatService : CrudQueryServiceBase<Friendship, FriendsWithChatDto, FriendshipFilterDto>, IFriendsWithChatService
    {
        public FriendsWithChatService(
            IMapper mapper,
            IRepository<Friendship> repository,
            QueryObjectBase<FriendsWithChatDto, Friendship, FriendshipFilterDto, IQuery<Friendship>> query)
            : base(mapper, repository, query) { }

        public async Task<QueryResultDto<FriendsWithChatDto, FriendshipFilterDto>> GetFriendsAsync(FriendshipFilterDto filter)
        {
            var queryResult = await Query.ExecuteQuery(filter);
            return queryResult;
        }
    }
}