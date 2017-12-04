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
    public class GetGroupUsersService : CrudQueryServiceBase<GroupUser, GetGroupUsersDto, GetGroupUsersFilterDto>, IGetGroupUsersService
    {
        public GetGroupUsersService(IMapper mapper, IRepository<GroupUser> repository,
            QueryObjectBase<GetGroupUsersDto, GroupUser, GetGroupUsersFilterDto, IQuery<GroupUser>> query)
            : base(mapper, repository, query)
        {
        }

        public async Task<IList<UserDto>> GetUsersByGroupIdAsync(int groupId)
        {
            var queryResult = await Query.ExecuteQuery(new GetGroupUsersFilterDto {GroupId = groupId});
            return queryResult?.Items.Select(groupUser => groupUser.UserDto).ToList();
        }
    }
}