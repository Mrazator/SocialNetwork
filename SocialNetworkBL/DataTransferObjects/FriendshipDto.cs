using System;
using SocialNetworkBL.DataTransferObjects.Common;

namespace SocialNetworkBL.DataTransferObjects
{
    public class FriendshipDto : DtoBase
    {
        public DateTime FriendshipStart { get; set; }
        public bool IsAccepted { get; set; }
        public int User1Id { get; set; }
        public int User2Id { get; set; }

        public BasicUserDto User1 { get; set; }
        public BasicUserDto User2 { get; set; }
    }
}