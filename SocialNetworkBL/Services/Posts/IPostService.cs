using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Services.Common;

namespace SocialNetworkBL.Services.Posts
{
    public interface IPostService : IService<PostDto, PostFilterDto>
    {
        Task<QueryResultDto<PostDto, PostFilterDto>> GetPostsAsync(PostFilterDto filter);

        Task<IList<PostDto>> GetPostsByUserIdAsync(int userId);

        Task<IList<PostDto>> GetPostsByGroupIdAsync(int groupId);
    }
}