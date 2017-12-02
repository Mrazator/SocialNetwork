using System.Collections.Generic;
using SocialNetworkBL.DataTransferObjects;

namespace SocialNetworkPL.Models
{
    public class UserProfileModel
    {
        public UserDto UserDto { get; set; }
        public string NewPostText { get; set; }
        public bool StayAnonymous { get; set; }
        public IList<int> FriendsIds { get; set; }
        public IList<PostDto> PostDtos { get; set; }
    }
}