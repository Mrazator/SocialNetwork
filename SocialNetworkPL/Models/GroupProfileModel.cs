using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.GroupProfileDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetworkPL.Models
{
    public class GroupProfileModel
    {
        public BasicUserDto AuthenticatedUser { get; set; }
        public GroupProfileDto GroupProfile { get; set; }
        
        public string NewPostText { get; set; }
        public bool PostStayAnonymous { get; set; }
        public string NewCommentText { get; set; }
        public int PostId { get; set; }
    }
}