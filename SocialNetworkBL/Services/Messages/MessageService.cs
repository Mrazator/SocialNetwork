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
using SocialNetworkDAL.Entities;

namespace SocialNetworkBL.Services.Messages
{
    public class MessageService : CrudQueryServiceBase<Message, MessageDto, MessageFilterDto>, IMessageService
    {
        public MessageService(IMapper mapper, IRepository<Message> repository,
            QueryObjectBase<MessageDto, Message, MessageFilterDto, IQuery<Message>> query)
            : base(mapper, repository, query)
        {
        }

        public async Task<QueryResultDto<MessageDto, MessageFilterDto>> GetMessagesByFriendshipIdAsync(int friendshipId)
        {
            var queryResult = await Query.ExecuteQuery(new MessageFilterDto {FriendshipId = friendshipId});
            return queryResult;
        }
    }
}