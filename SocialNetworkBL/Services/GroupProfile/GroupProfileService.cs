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
    public class GroupProfileService : ServiceBase, IGroupProfileService
    {
        private readonly QueryObjectBase<GroupProfileDto, Group, GroupFilterDto, IQuery<Group>> _groupProfileQueryObject;
        private readonly IRepository<Group> _repository;

        public GroupProfileService(IMapper mapper,
                                    QueryObjectBase<GroupProfileDto, Group, GroupFilterDto, IQuery<Group>> queryObject,
                                    IRepository<Group> repository) : 
                                    base(mapper)
        {
            _groupProfileQueryObject = queryObject;
            _repository = repository;
        }

        public async Task<GroupProfileDto> GetGroupProfileAsync(int id)
        {
            var group = await _repository.GetAsync(id);
            return group != null ? Mapper.Map<GroupProfileDto>(group) : null;
        }
    }
}
