using AutoMapper;
using Infrastructure.Query;
using Infrastructure.Query.Predicates;
using Infrastructure.Query.Predicates.Operators;
using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.DataTransferObjects.UserDetailDto;
using SocialNetworkBL.QueryObjects.Common;

namespace SocialNetworkBL.QueryObjects
{
    public class UserDetailQueryObject : QueryObjectBase<UserDetailDto, User, UserFilterDto, IQuery<User>>
    {
        public UserDetailQueryObject(IMapper mapper, IQuery<User> query) : base(mapper, query)
        {
        }

        protected override IQuery<User> ApplyWhereClause(IQuery<User> query, UserFilterDto filter)
        {
            var simplePredicate = new SimplePredicate(nameof(User.NickName), ValueComparingOperator.StringContains,
                filter.SubName);

            return filter.Equals(null)
                ? query
                : query.Where(simplePredicate);
        }
    }
}