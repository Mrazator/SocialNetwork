using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Filters;

namespace SocialNetworkBL.DataTransferObjects.ChatDtos
{
    public class FriendsWithChatDto : DtoBase
    {
        //public DateTime FriendshipStart { get; set; }
        //public bool IsAccepted { get; set; }
        public int User1Id { get; set; }
        public int User2Id { get; set; }

        public BasicUserDto User1 { get; set; }
        public BasicUserDto User2 { get; set; }

        //not mapped
        public QueryResultDto<MessageDto, MessageFilterDto> Chat { get; set; }
    }
}
