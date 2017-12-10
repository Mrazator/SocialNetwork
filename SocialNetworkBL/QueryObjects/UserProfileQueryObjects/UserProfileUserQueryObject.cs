using AutoMapper;
using Infrastructure.Query;
using Infrastructure.Query.Predicates;
using Infrastructure.Query.Predicates.Operators;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.DataTransferObjects.UserProfileDtos;
using SocialNetworkBL.QueryObjects.Common;
using SocialNetworkDAL.Entities;

namespace SocialNetworkBL.QueryObjects.UserProfileQueryObjects
{
    public class UserProfileUserQueryObject : QueryObjectBase<UserProfileUserDto, User, UserFilterDto, IQuery<User>>
    {
        public UserProfileUserQueryObject(IMapper mapper, IQuery<User> query) : base(mapper, query)
        {
        }

        protected override IQuery<User> ApplyWhereClause(IQuery<User> query, UserFilterDto filter)
        {
            var simplePredicate = new SimplePredicate(nameof(User.NickName), ValueComparingOperator.Equal, filter.NickName);

            return string.IsNullOrEmpty(filter.NickName)
                ? query
                : query.Where(simplePredicate);
        }
    }
}