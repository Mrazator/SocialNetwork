using AutoMapper;
using Infrastructure;
using Infrastructure.Query;
using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.DataTransferObjects.UserDetailDto;
using SocialNetworkBL.QueryObjects.Common;
using SocialNetworkBL.Services.Common;

namespace SocialNetworkBL.Services.UserDetail
{
    public class UserDetailService : CrudQueryServiceBase<User, UserDetailDto, UserFilterDto>,
        IService<UserDetailDto, UserFilterDto>
    {
        public UserDetailService(IMapper mapper, IRepository<User> repository,
            QueryObjectBase<UserDetailDto, User, UserFilterDto, IQuery<User>> query)
            : base(mapper, repository, query)
        {
        }
    }
}