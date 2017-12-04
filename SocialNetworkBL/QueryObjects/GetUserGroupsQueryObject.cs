using AutoMapper;
using Infrastructure.Query;
using Infrastructure.Query.Predicates;
using Infrastructure.Query.Predicates.Operators;
using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.QueryObjects.Common;

namespace SocialNetworkBL.QueryObjects
{
    public class GetUserGroupsQueryObject : QueryObjectBase<GetUserGroupsDto, GroupUser, GetUserGroupsFilterDto, IQuery<GroupUser>>
    {
        public GetUserGroupsQueryObject(IMapper mapper, IQuery<GroupUser> query) : base(mapper, query)
        {
        }

        protected override IQuery<GroupUser> ApplyWhereClause(IQuery<GroupUser> query, GetUserGroupsFilterDto filter)
        {
            var simplePredicate =
                new SimplePredicate(nameof(GroupUser.GroupId), ValueComparingOperator.Equal, filter.UserId);

            return filter.UserId.Equals(null)
                ? query
                : query.Where(simplePredicate);
        }
    }
}