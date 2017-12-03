using System.Collections.Generic;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using X.PagedList;

namespace SocialNetworkPL.Models
{
    public class PostListModel
    {
        public UserDto AuthenticatedUser { get; set; }
        public PostFilterDto Filter { get; set; }
        public string CommentText { get; set; }
        public bool StayAnonymous { get; set; }
        public int PostId { get; set; }
        public IEnumerable<PostDto> Posts { get; set; }
        public IEnumerable<UserDto> Users { get; set; }
    }
}