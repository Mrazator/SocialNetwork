using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.ChatDtos;
using SocialNetworkBL.DataTransferObjects.Filters;

namespace SocialNetworkPL.Models
{
    public class ChatModel
    {
        public BasicUserDto AuthenticatedUser { get; set; }
        public IEnumerable<FriendsWithChatDto> FriendWithChat { get; set; }

        public FriendshipFilterDto Filter { get; set; }
    }
}