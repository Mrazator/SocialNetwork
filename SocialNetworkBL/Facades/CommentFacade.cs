using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Facades.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.UnitOfWork;
using SocialNetworkBL.Services.Common;
using SocialNetworkBL.Services.Comments;
using Comment = SocialNetwork.Entities.Comment;

namespace SocialNetworkBL.Facades
{
    public class CommentFacade : FacadeBase<Comment, CommentDto, CommentFilterDto>
    {
        private readonly ICommentService _commentService;

        public CommentFacade(
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
