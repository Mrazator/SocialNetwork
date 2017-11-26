using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworkBL.DataTransferObjects.Common;

namespace SocialNetworkBL.Services.Posts
{
    public interface IPostService : IService<PostDto, PostFilterDto>
    {
        Task<QueryResultDto<PostDto, PostFilterDto>> GetPostsAsync(PostFilterDto filter);

        Task<IList<PostDto>> GetPostsByUserIdAsync(int userId);

        Task<IList<PostDto>> GetPostsByGroupIdAsync(int groupId);

    }
}
