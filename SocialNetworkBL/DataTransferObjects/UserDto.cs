using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBL.DataTransferObjects
{
    public class UserDto : DtoBase
    {
        public string NickName { get; set; }

        public string PasswordHash { get; set; } = "password";

        public Visibility PostVisibilityPreference { get; set; } = Visibility.Visible;

        //public virtual HashSet<FriendshipDto> RequestedFriendships { get; set; }
        //public virtual HashSet<FriendshipDto> AcceptedFriendships { get; set; }
        //public virtual HashSet<PostDto> Posts { get; set; }
        //public virtual HashSet<GroupUserDto> GroupUsers { get; set; }
        //public virtual HashSet<CommentDto> Comments { get; set; }
    }
}
