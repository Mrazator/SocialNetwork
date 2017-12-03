using System;
using System.Collections.Generic;
using SocialNetworkBL.DataTransferObjects.Common;

namespace SocialNetworkBL.DataTransferObjects
{
    public class PostDto : DtoBase
    {
        public DateTime PostedAt { get; set; }

        public string Text { get; set; }

        public bool StayAnonymous { get; set; } = false;

        public int? UserId { get; set; }

        public int? GroupId { get; set; }

        public HashSet<CommentDto> Comments { get; set; }
    }
}