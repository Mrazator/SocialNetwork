using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBL.Services.Comments
{
    public interface ICommentService : IService<CommentDto, CommentFilterDto>
    {
        Task<IList<CommentDto>> GetCommentsByPostIdAsync(int postId);

        Task<IList<CommentDto>> GetLatestCommentsByPostIdAsync(int postId, int pageSize);
    }
}
