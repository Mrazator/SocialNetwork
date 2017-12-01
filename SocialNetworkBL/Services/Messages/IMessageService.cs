using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Services.Common;

namespace SocialNetworkBL.Services.Messages
{
    public interface IMessageService : IService<MessageDto, MessageFilterDto>
    {
        Task<IList<MessageDto>> GetMessagesByFriendshipIdAsync(int friendshipId);
    }
}