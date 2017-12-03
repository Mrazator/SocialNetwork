using System.Collections.Generic;
using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Enums;

namespace SocialNetworkBL.DataTransferObjects
{
    public class UserDto : DtoBase
    {
        public string NickName { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        //public Visibility PostVisibilityPreference { get; set; } = Visibility.Visible;
        public string ProfileDescription { get; set; }

        public virtual HashSet<FriendshipDto> RequestedFriendships { get; set; }
        public virtual HashSet<FriendshipDto> AcceptedFriendships { get; set; }
    }
}