using System.Collections.Generic;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using X.PagedList;

namespace SocialNetworkPL.Models
{
    public class PostListModel
    {
        public IEnumerable<PostDto> Posts { get; set; }
        public IEnumerable<UserDto> Users { get; set; }
        public PostFilterDto Filter { get; set; }
    }
}