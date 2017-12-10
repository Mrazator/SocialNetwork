using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Query;
using Infrastructure.UnitOfWork;
using SocialNetworkBL.DataTransferObjects.ChatDtos;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Facades.Common;
using SocialNetworkBL.Services.Chat;
using SocialNetworkBL.Services.Messages;

namespace SocialNetworkBL.Facades
{
    public class FriendsWithChatFacade : FacadeBase
    {
        private readonly IFriendsWithChatService _friendsWithChatService;
        private readonly IMessageService _messageService;

        public FriendsWithChatFacade(
            IUnitOfWorkProvider unitOfWorkProvider,
            IFriendsWithChatService friendsWithChatService,
            IMessageService messageService)
            : base(unitOfWorkProvider)
        {
            _friendsWithChatService = friendsWithChatService;
            _messageService = messageService;
        }

        public async Task<QueryResultDto<FriendsWithChatDto, FriendshipFilterDto>> GetFriendsWithChatAsync(FriendshipFilterDto filter)
        {
            using (UnitOfWorkProvider.Create())
            {
                var friends = await _friendsWithChatService.GetFriendsAsync(filter);

                foreach (var friendship in friends.Items)
                {
                    friendship.Chat = await _messageService.GetMessagesByFriendshipIdAsync(friendship.Id);
                }

                return friends;
            }
        }
    }
}
