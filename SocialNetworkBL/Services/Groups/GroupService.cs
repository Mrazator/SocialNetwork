using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure;
using Infrastructure.Query;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.QueryObjects.Common;
using SocialNetworkBL.Services.Common;
using System;
using SocialNetworkDAL.Entities;

namespace SocialNetworkBL.Services.Groups
{
    public class GroupService : CrudQueryServiceBase<Group, GroupDto, GroupFilterDto>, IGroupService
    {
        public GroupService(IMapper mapper, IRepository<Group> repository,
            QueryObjectBase<GroupDto, Group, GroupFilterDto, IQuery<Group>> query)
            : base(mapper, repository, query) { }

        public async Task<IList<GroupDto>> GetGroupsContainingSubNameAsync(string subName)
        {
            var queryResult = await Query.ExecuteQuery(new GroupFilterDto {SubName = subName});
            return queryResult?.Items.ToList();
        }

        public async Task<int> CreateGroupAsync(GroupCreateDto groupDto)
        {
            var group = Mapper.Map<Group>(groupDto);

            if (await GetIfGroupExistsAsync(group.Name))
                throw new ArgumentException();

            Repository.Create(group);

            return group.Id;
        }

        private async Task<bool> GetIfGroupExistsAsync(string groupName)
        {
            var queryResult = await Query.ExecuteQuery(new GroupFilterDto { GroupName = groupName });
            return queryResult.Items.Count() == 1;
        }
    }
}