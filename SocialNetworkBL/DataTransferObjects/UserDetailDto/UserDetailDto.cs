using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworkBL.DataTransferObjects.Common;

namespace SocialNetworkBL.DataTransferObjects.UserDetailDto
{
    public class UserDetailDto : DtoBase
    {
        public string NickName { get; set; }

        public virtual HashSet<FriendshipDetailDto> RequestedFriendships { get; set; }
        public virtual HashSet<FriendshipDetailDto> AcceptedFriendships { get; set; }
        public virtual HashSet<PostDto> Posts { get; set; }
    }
}
