using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure;
using Infrastructure.Query;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.QueryObjects.Common;
using SocialNetworkBL.Services.Common;

namespace SocialNetworkBL.Services.BasicUser
{
    public class BasicUsersService : CrudQueryServiceBase<SocialNetwork.Entities.User, BasicUserDto, UserFilterDto>, IBasicUsersService
    {
        private readonly IRepository<SocialNetwork.Entities.User> _repository;
        private readonly QueryObjectBase<BasicUserDto, SocialNetwork.Entities.User, UserFilterDto, IQuery<SocialNetwork.Entities.User>> _query;


        public BasicUsersService(IMapper mapper,
            IRepository<SocialNetwork.Entities.User> repository,
            QueryObjectBase<BasicUserDto, SocialNetwork.Entities.User, UserFilterDto, IQuery<SocialNetwork.Entities.User>> query)
            : base(mapper, repository, query)
        {
            _repository = repository;
            _query = query;
        }

        public async Task<BasicUserDto> GetUsersByNickName(string nickName)
        {
            var query = await _query.ExecuteQuery(new UserFilterDto()
            {
                NickName = nickName
            });

            return query?.Items?.SingleOrDefault();
        }

        public async Task<IEnumerable<BasicUserDto>> GetUsersContainingSubNameAsync(string subName)
        {
            var queryResult = await _query.ExecuteQuery(new UserFilterDto { SubName = subName });
            return queryResult?.Items;
        }
    }
}
