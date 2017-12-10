using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure;
using Infrastructure.Query;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.DataTransferObjects.UserProfileDtos;
using SocialNetworkBL.QueryObjects.Common;
using SocialNetworkBL.Services.Common;
using SocialNetworkDAL.Entities;

namespace SocialNetworkBL.Services.UserProfile
{
    public class UserProfilePostService : CrudQueryServiceBase<Post, UserProfilePostDto, PostFilterDto>, IUserProfilePostService
    {
        public UserProfilePostService(
            IMapper mapper,
            IRepository<Post> repository,
            QueryObjectBase<UserProfilePostDto, Post, PostFilterDto, IQuery<Post>> query)
            : base(mapper, repository, query)
        {
        }

        public async Task<QueryResultDto<UserProfilePostDto, PostFilterDto>> GetPostsByFilterAsync(PostFilterDto filter)
        {
            return await Query.ExecuteQuery(filter);
        }
    }
}
