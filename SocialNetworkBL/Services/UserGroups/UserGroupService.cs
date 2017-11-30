using AutoMapper;
using Infrastructure;
using Infrastructure.Query;
using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.QueryObjects.Common;
using SocialNetworkBL.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBL.Services.UserGroups
{
    public class UserGroupService : CrudQueryServiceBase<GroupUser, UserGroupDto, UserGroupFilterDto>, IUserGroupService
    {
        public UserGroupService(IMapper mapper, IRepository<GroupUser> repository,
            QueryObjectBase<UserGroupDto, GroupUser, UserGroupFilterDto, IQuery<GroupUser>> query)
            : base(mapper, repository, query)
        {
        }

        public async Task<IList<GroupDto>> GetGroupsByUserIdAsync(int userId)
        {
            var queryResult = await Query.ExecuteQuery(new UserGroupFilterDto { UserId = userId });
            return queryResult?.Items.Select(userGroup => userGroup.GroupDto).ToList();
        }
    }
}
