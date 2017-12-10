using System.Collections.Generic;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.DataTransferObjects.UserProfileDtos;
using X.PagedList;

namespace SocialNetworkPL.Models
{
    public class UserProfileModel
    {
        public BasicUserDto AuthenticatedUser { get; set; }
        public UserProfileUserDto UserProfileUser { get; set; }
        public PostFilterDto PostFilter { get; set; }
        public CommentFilterDto CommentFilter { get; set; }

        public string NewPostText { get; set; }
        public bool PostIsVisibleOnlyToFriends { get; set; }
        public string NewCommentText { get; set; }
        public int PostId { get; set; }
    }
}