using SocialNetworkBL.DataTransferObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBL.DataTransferObjects
{
    public class MessageDto : DtoBase
    {
        //public DateTime SentAt { get; set; }

        public string Text { get; set; }

        public int SenderId { get; set; }

        public int FriendshipId { get; set; }
    }
}
