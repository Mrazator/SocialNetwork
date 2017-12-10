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
using SocialNetworkBL.DataTransferObjects.Common;

namespace SocialNetworkBL.Services.GroupProfile
{
    public class GroupProfileUserService : CrudQueryServiceBase<SocialNetworkDAL.Entities.User, GroupProfileUserDto, UserFilterDto>, IGroupProfileUserService
    {
        public GroupProfileUserService(IMapper mapper, 
                                       IRepository<SocialNetworkDAL.Entities.User> repository,
                                       QueryObjectBase<GroupProfileUserDto, SocialNetworkDAL.Entities.User, UserFilterDto, IQuery<SocialNetworkDAL.Entities.User>> query)
                                       : base(mapper, repository, query) { }

    }
}
