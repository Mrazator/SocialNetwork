using System.Collections.Generic;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.UserProfileDtos;

namespace SocialNetworkPL.Models
{
    public class UserProfileModel
    {
        public BasicUserDto AuthenticatedUser { get; set; }

        public string NewPostText { get; set; }
        public bool PostStayAnonymous { get; set; }
        public string NewCommentText { get; set; }
        public int PostId { get; set; }

        //new
        public UserProfileUserDto UserProfileUser { get; set; }

    }
}