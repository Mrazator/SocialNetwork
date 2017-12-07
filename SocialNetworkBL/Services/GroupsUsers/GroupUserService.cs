using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
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

namespace SocialNetworkBL.Services.GroupsUsers
{
    public class GroupUserService : CrudQueryServiceBase<GroupUser, GroupUserDto, GroupUserFilterDto>, IGroupUserService
    {
        public GroupUserService(IMapper mapper, IRepository<GroupUser> repository,
            QueryObjectBase<GroupUserDto, GroupUser, GroupUserFilterDto, IQuery<GroupUser>> query)
            : base(mapper, repository, query) { }

        public async Task<GroupUserDto> GetGroupUserAsync(int groupId, int userId)
        {
            var queryResult = await Query.ExecuteQuery(new GroupUserFilterDto { GroupId = groupId, UserId = userId });
            return queryResult.Items.SingleOrDefault();
        }

        public async Task<int> AddUserToGroupAsync(AddUserToGroupDto userToGroupDto, bool isAdmin = false)
        {
            if (await GetIfGroupUserExistsAsync(userToGroupDto.GroupId, userToGroupDto.UserId))
                throw new ArgumentException();

            var groupUser = Mapper.Map<GroupUser>(userToGroupDto);

            groupUser.IsAdmin = isAdmin;

            Repository.Create(groupUser);

            return groupUser.Id;
        }



        private async Task<bool> GetIfGroupUserExistsAsync(int groupId, int userId)
        {
            var queryResult = await Query.ExecuteQuery(new GroupUserFilterDto { GroupId = groupId, UserId = userId });
            return queryResult.Items.Count() == 1;
        }
    }
}
