using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.UnitOfWork;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Facades.Common;
using SocialNetworkBL.Services.Comments;
using SocialNetworkBL.Services.Common;
using SocialNetworkDAL.Entities;

namespace SocialNetworkBL.Facades
{
    public class CommentGenericFacade : GenericFacadeBase<Comment, CommentDto, CommentFilterDto>
    {
        private readonly ICommentService _commentService;

        public CommentGenericFacade(
            IUnitOfWorkProvider unitOfWorkProvider,
            CrudQueryServiceBase<Comment, CommentDto, CommentFilterDto> service,
            ICommentService commentService)
            : base(unitOfWorkProvider, service)
        {
            _commentService = commentService;
        }

        public async Task<IList<CommentDto>> GetPostLatestCommentsAsync(int postId, int pageSize)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await _commentService.GetLatestCommentsByPostIdAsync(postId, pageSize);
            }
        }

        public async Task<IList<CommentDto>> GetPostCommentsAsync(int postId)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await _commentService.GetCommentsByPostIdAsync(postId);
            }
        }
    }
}