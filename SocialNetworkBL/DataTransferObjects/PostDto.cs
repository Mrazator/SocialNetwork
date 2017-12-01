using SocialNetworkBL.DataTransferObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBL.DataTransferObjects
{
    public class PostDto : DtoBase
    {
        public DateTime PostedAt { get; set; }

        public string Text { get; set; }

        public bool StayAnonymous { get; set; } = false;

        public int? UserId { get; set; } 

        public int? GroupId { get; set; }
    }
}
