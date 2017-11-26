using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworkBL.DataTransferObjects.Common;

namespace SocialNetworkBL.DataTransferObjects.UserDetailDto
{
    public class FriendshipDetailDto : DtoBase
    {
        public DateTime FriendshipStart { get; set; }
        public UserDetailDto User1 { get; set; }
        public UserDetailDto User2 { get; set; }

    }
}
