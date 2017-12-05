using System;
using SocialNetworkBL.DataTransferObjects.Common;

namespace SocialNetworkBL.DataTransferObjects
{
    public class CommentDto : DtoBase
    {
        public DateTime PostedAt { get; set; }

        public string Text { get; set; }

        public bool StayAnonymous { get; set; } = false;

        public int PostId { get; set; }

        public int UserId { get; set; }

        public string NickName { get; set; }
    }
}