using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using X.PagedList;
using System.Collections.Generic;

namespace SocialNetworkPL.Models
{
    public class PostsListViewModel
    {
        public IPagedList<PostDto> Posts { get; set; }
        public IEnumerable<UserDto> Users { get; set; }
        public PostFilterDto Filter { get; set; }
    }
}