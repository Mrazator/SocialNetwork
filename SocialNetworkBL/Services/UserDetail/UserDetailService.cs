using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure;
using Infrastructure.Query;
using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.DataTransferObjects.UserDetailDto;
using SocialNetworkBL.QueryObjects.Common;
using SocialNetworkBL.Services.Common;
using SocialNetworkBL.Services.Users;

namespace SocialNetworkBL.Services.UserDetail
{
    public class UserDetailService : CrudQueryServiceBase<User, UserDetailDto, UserFilterDto>, IService<UserDetailDto, UserFilterDto>
    {
        public UserDetailService(IMapper mapper, IRepository<User> repository,
            QueryObjectBase<UserDetailDto, User, UserFilterDto, IQuery<User>> query)
            : base(mapper, repository, query)
        {
        }
    }
}
