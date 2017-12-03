using System.Collections.Generic;
using SocialNetworkBL.DataTransferObjects;

namespace SocialNetworkPL.Models
{
    public class UserProfileModel
    {
        public UserDto AuthenticatedUser{ get; set; }
        public UserDto UserProfileDto { get; set; }
        public string NewPostText { get; set; }
        public string CommentText { get; set; }
        public bool StayAnonymous { get; set; }
        public int PostId { get; set; }
        public IList<int> FriendsIds { get; set; }
        public IList<PostDto> PostDtos { get; set; }
        public IEnumerable<UserDto> Users { get; set; }

    }
}