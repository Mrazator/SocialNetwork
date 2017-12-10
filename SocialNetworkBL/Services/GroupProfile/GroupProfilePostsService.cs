using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.DataTransferObjects.GroupProfileDtos;
using SocialNetworkBL.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure;
using Infrastructure.Query;
using SocialNetworkBL.QueryObjects.Common;
using SocialNetworkDAL.Entities;

namespace SocialNetworkBL.Services.GroupProfile
{
    public class GroupProfilePostsService : CrudQueryServiceBase<Post, GroupProfilePostDto, PostFilterDto>, IGroupProfilePostsService
    {
        public GroupProfilePostsService(IMapper mapper,
                                        IRepository<Post> repository,
                                        QueryObjectBase<GroupProfilePostDto, Post, PostFilterDto, IQuery<Post>> query) : 
                                        base(mapper, repository, query) { }

        public async Task<IList<GroupProfilePostDto>> GetGroupProfilePostsAsync(int groupId)
        {
            var queryResult = await Query.ExecuteQuery(new PostFilterDto
            {
                GroupId = groupId,
                UserId = null,
                SortAscending = false,
                SortCriteria = nameof(Post.PostedAt)
            });
            return queryResult?.Items.ToList();
        }
    }
}
