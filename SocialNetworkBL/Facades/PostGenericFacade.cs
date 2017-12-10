using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.UnitOfWork;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Facades.Common;
using SocialNetworkBL.Services.Common;
using SocialNetworkBL.Services.Posts;
using SocialNetworkDAL.Entities;

namespace SocialNetworkBL.Facades
{
    public class PostGenericFacade : GenericFacadeBase<Post, PostDto, PostFilterDto>
    {
        private readonly IPostService _postService;

        public PostGenericFacade(
            IUnitOfWorkProvider unitOfWorkProvider,
            CrudQueryServiceBase<Post, PostDto, PostFilterDto> service,
            IPostService postService)
            : base(unitOfWorkProvider, service)
        {
            _postService = postService;
        }

        public async Task<QueryResultDto<PostDto, PostFilterDto>> GetPostsAsync(PostFilterDto filter)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await _postService.GetPostsAsync(filter);
            }
        }

        public async Task<IList<PostDto>> GetPostsByGroupIdAsync(int groupId)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await _postService.GetPostsByGroupIdAsync(groupId);
            }
        }

        public async Task<IList<PostDto>> GetPostsByUserIdAsync(int userId)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await _postService.GetPostsByUserIdAsync(userId);
            }
        }
    }
}