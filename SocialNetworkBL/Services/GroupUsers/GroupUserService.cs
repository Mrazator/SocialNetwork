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

namespace SocialNetworkBL.Services.GroupUsers
{
    public class GroupUserService : CrudQueryServiceBase<GroupUser, GroupUserDto, GroupUserFilterDto>, IGroupUserService
    {
        protected GroupUserService(IMapper mapper, IRepository<GroupUser> repository,
            QueryObjectBase<GroupUserDto, GroupUser, GroupUserFilterDto, IQuery<GroupUser>> query)
            : base(mapper, repository, query)
        {
        }

        public async Task<IList<GroupUserDto>> GetGroupsByUserIdAsync(int userId)
        {
            var queryResult = await Query.ExecuteQuery(new GroupUserFilterDto {UserId = userId});
            return queryResult?.Items.ToList();
        }

        public async Task<IList<GroupUserDto>> GetUsersByGroupIdAsync(int groupId)
        {
            var queryResult = await Query.ExecuteQuery(new GroupUserFilterDto {GroupId = groupId});
            return queryResult?.Items.ToList();
        }
    }
}