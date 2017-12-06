using System.Collections.Generic;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.DataTransferObjects.UserProfileDtos;
using X.PagedList;

namespace SocialNetworkPL.Models
{
    public class PostListModel
    {
        public BasicUserDto AuthenticatedUser { get; set; }
        public PostFilterDto PostFilter { get; set; }
        public CommentFilterDto CommentFilter { get; set; }
        public QueryResultDto<UserProfilePostDto, PostFilterDto> Posts { get; set; }
        public string NewCommentText { get; set; }
        public bool StayAnonymous { get; set; }
        public int PostId { get; set; }

    }
}