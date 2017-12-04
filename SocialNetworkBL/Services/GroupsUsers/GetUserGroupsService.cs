using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure;
using Infrastructure.Query;
using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.QueryObjects.Common;
using SocialNetworkBL.Services.Common;

namespace SocialNetworkBL.Services.GroupsUsers
{
    public class GetUserGroupsService : CrudQueryServiceBase<GroupUser, GetUserGroupsDto, GetUserGroupsFilterDto>, IGetUserGroupsService
    {
        public GetUserGroupsService(IMapper mapper, IRepository<GroupUser> repository,
            QueryObjectBase<GetUserGroupsDto, GroupUser, GetUserGroupsFilterDto, IQuery<GroupUser>> query)
            : base(mapper, repository, query)
        {
        }

        public async Task<IList<GroupDto>> GetGroupsByUserIdAsync(int userId)
        {
            var queryResult = await Query.ExecuteQuery(new GetUserGroupsFilterDto {UserId = userId});
            return queryResult?.Items.Select(userGroup => userGroup.GroupDto).ToList();
        }
    }
}