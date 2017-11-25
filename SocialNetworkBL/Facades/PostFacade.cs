using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.Facades.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.UnitOfWork;
using SocialNetworkBL.Services.Common;
using SocialNetworkBL.Services.Posts;
using SocialNetworkBL.DataTransferObjects.Filters;
using Post = SocialNetwork.Entities.Post;

namespace SocialNetworkBL.Facades
{
    public class PostFacade : FacadeBase<Post, PostDto, PostFilterDto>
    {
        private readonly IPostService _postService;

        public PostFacade(
            IUnitOfWorkProvider unitOfWorkProvider,
            CrudQueryServiceBase<Post, PostDto, PostFilterDto> service,
            IPostService postService)
            : base(unitOfWorkProvider, service)
        {
            _postService = postService;
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
                return await _postService.GetPostsByGroupIdAsync(userId);
            }
        }
    }
}
