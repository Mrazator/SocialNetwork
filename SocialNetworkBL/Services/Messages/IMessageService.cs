using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Services.Common;

namespace SocialNetworkBL.Services.Messages
{
    public interface IMessageService : IService<MessageDto, MessageFilterDto>
    {
        Task<QueryResultDto<MessageDto, MessageFilterDto>> GetMessagesByFriendshipIdAsync(int friendshipId);
    }
}