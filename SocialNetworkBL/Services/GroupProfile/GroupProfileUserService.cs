using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.DataTransferObjects.GroupProfileDtos;
using SocialNetworkBL.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Entities;
using AutoMapper;
using Infrastructure;
using Infrastructure.Query;
using SocialNetworkBL.QueryObjects.Common;
using SocialNetworkBL.DataTransferObjects.Common;

namespace SocialNetworkBL.Services.GroupProfile
{
    public class GroupProfileUserService : CrudQueryServiceBase<SocialNetwork.Entities.User, GroupProfileUserDto, UserFilterDto>, IGroupProfileUserService
    {
        public GroupProfileUserService(IMapper mapper, 
                                       IRepository<SocialNetwork.Entities.User> repository,
                                       QueryObjectBase<GroupProfileUserDto, SocialNetwork.Entities.User, UserFilterDto, IQuery<SocialNetwork.Entities.User>> query)
                                       : base(mapper, repository, query) { }

    }
}
