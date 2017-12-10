using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworkBL.DataTransferObjects.ChatDtos;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Services.Common;

namespace SocialNetworkBL.Services.Chat
{
    public interface IFriendsWithChatService : IService<FriendsWithChatDto, FriendshipFilterDto>
    {
        Task<QueryResultDto<FriendsWithChatDto, FriendshipFilterDto>> GetFriendsAsync(FriendshipFilterDto filter);
    }
}
