using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure;
using Infrastructure.Query;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.DataTransferObjects.GroupProfileDtos;
using SocialNetworkBL.QueryObjects.Common;
using SocialNetworkBL.Services.Common;
using SocialNetworkDAL.Entities;

namespace SocialNetworkBL.Services.GroupsUsers
{
    public class GetGroupUsersService : CrudQueryServiceBase<GroupUser, GetGroupUsersDto, GetGroupUsersFilterDto>, IGetGroupUsersService
    {
        public GetGroupUsersService(IMapper mapper, IRepository<GroupUser> repository,
            QueryObjectBase<GetGroupUsersDto, GroupUser, GetGroupUsersFilterDto, IQuery<GroupUser>> query)
            : base(mapper, repository, query)
        {
        }

        public async Task<IList<GroupProfileUserDto>> GetGroupUsersAsync(int groupId)
        {
            var queryResult = await Query.ExecuteQuery(new GetGroupUsersFilterDto { GroupId = groupId });

            foreach (var item in queryResult.Items)
            {
                item.User.IsAdmin = item.IsAdmin;
                item.User.IsAccepted = item.IsAccepted;
            }

            return queryResult?.Items.Select(groupUser => groupUser.User).ToList();
        }
    }
}