using AutoMapper;
using Infrastructure.Query;
using Infrastructure.Query.Predicates;
using Infrastructure.Query.Predicates.Operators;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.QueryObjects.Common;
using SocialNetworkDAL.Entities;

namespace SocialNetworkBL.QueryObjects
{
    public class BasicUsersQueryObject : QueryObjectBase<BasicUserDto, User, UserFilterDto, IQuery<User>>
    {
        public BasicUsersQueryObject(IMapper mapper, IQuery<User> query) : base(mapper, query)
        {
        }

        protected override IQuery<User> ApplyWhereClause(IQuery<User> query, UserFilterDto filter)
        {
            var simplePredicate = filter.SubName == null
                ? new SimplePredicate(nameof(User.NickName), ValueComparingOperator.Equal, filter.NickName)
                : new SimplePredicate(nameof(User.NickName), ValueComparingOperator.StringContains, filter.SubName);

            return filter.NickName == null && filter.SubName == null
                ? query
                : query.Where(simplePredicate);
        }
    }
}
