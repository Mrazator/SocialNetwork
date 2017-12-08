using SocialNetwork.Entities;
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

namespace SocialNetworkBL.Services.GroupProfile
{
    public class GroupProfileService : CrudQueryServiceBase<Group, GroupProfileDto, GroupFilterDto>, IGroupProfileService
    {
        public GroupProfileService(IMapper mapper, IRepository<Group> repository,
                                    QueryObjectBase<GroupProfileDto, Group, GroupFilterDto, IQuery<Group>> query) : 
                                    base(mapper, repository, query) {  }

        public async Task<GroupProfileDto> GetGroupProfileAsync(int id)
        {
            var group = await Repository.GetAsync(id);
            return group != null ? Mapper.Map<GroupProfileDto>(group) : null;
        }
    }
}
