using System;
using SocialNetworkBL.DataTransferObjects.Common;

namespace SocialNetworkBL.DataTransferObjects
{
    public class MessageDto : DtoBase
    {
        public DateTime SentAt { get; set; }

        public string Text { get; set; }

        public int SenderId { get; set; }

        public int FriendshipId { get; set; }
    }
}