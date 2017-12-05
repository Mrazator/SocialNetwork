using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Services.Common;

namespace SocialNetworkBL.Services.Comments
{
    public interface ICommentService : IService<CommentDto, CommentFilterDto>
    {
        Task<IList<CommentDto>> GetCommentsByPostIdAsync(int postId);

        Task<IList<CommentDto>> GetLatestCommentsByPostIdAsync(int postId, int pageSize);

        Task<QueryResultDto<CommentDto, CommentFilterDto>> GetCommentsByFilter(CommentFilterDto filter);
    }
}