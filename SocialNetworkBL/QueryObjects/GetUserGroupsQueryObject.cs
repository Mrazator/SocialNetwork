using AutoMapper;
using Infrastructure.Query;
using Infrastructure.Query.Predicates;
using Infrastructure.Query.Predicates.Operators;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.QueryObjects.Common;
using System.Collections.Generic;
using SocialNetworkDAL.Entities;

namespace SocialNetworkBL.QueryObjects
{
    public class GetUserGroupsQueryObject : QueryObjectBase<GetUserGroupsDto, GroupUser, GetUserGroupsFilterDto, IQuery<GroupUser>>
    {
        public GetUserGroupsQueryObject(IMapper mapper, IQuery<GroupUser> query) : base(mapper, query)
        {
        }

        protected override IQuery<GroupUser> ApplyWhereClause(IQuery<GroupUser> query, GetUserGroupsFilterDto filter)
        {
            //var simplePredicate =
            //    new SimplePredicate(nameof(GroupUser.GroupId), ValueComparingOperator.Equal, filter.UserId);

            //return filter.UserId.Equals(null)
            //    ? query
            //    : query.Where(simplePredicate);

            var compositePredicate = new CompositePredicate(new List<IPredicate>
            {
                new SimplePredicate(nameof(GroupUser.UserId), ValueComparingOperator.Equal, filter.UserId)
            });

            if (filter.IsAccepted != null)
            {
                compositePredicate.Predicates.Add(new SimplePredicate(nameof(GroupUser.IsAccepted), ValueComparingOperator.Equal, filter.IsAccepted));
            }

            return filter.UserId.Equals(null)
                ? query
                : query.Where(compositePredicate);
        }
    }
}