using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.UserDetailDto;

namespace SocialNetworkPL.Models
{
    public class UserDetailViewModel
    {
        public UserDto UserDto { get; set; }
        public string NewPostText { get; set; }
        public IList<UserDto> FriendshipDtos { get; set; }
        public IList<PostDto> PostDtos { get; set; }
    }
}