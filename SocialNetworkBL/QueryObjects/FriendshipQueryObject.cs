using System.Collections.Generic;
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
    public class FriendshipQueryObject : QueryObjectBase<FriendshipDto, Friendship, FriendshipFilterDto, IQuery<Friendship>>
    {
        public FriendshipQueryObject(IMapper mapper, IQuery<Friendship> query) : base(mapper, query) { }

        protected override IQuery<Friendship> ApplyWhereClause(IQuery<Friendship> query, FriendshipFilterDto filter)
        {
            var wherePredicate = new CompositePredicate(new List<IPredicate>
            {
                new SimplePredicate(nameof(Friendship.User1Id), ValueComparingOperator.Equal, filter.UserId),
                new SimplePredicate(nameof(Friendship.User2Id), ValueComparingOperator.Equal, filter.UserId)
            }, LogicalOperator.OR);

            var compositePredicate = new CompositePredicate(new List<IPredicate>()
            {
                wherePredicate,
                new SimplePredicate(nameof(Friendship.IsAccepted), ValueComparingOperator.Equal, filter.IsAccepted)
            }, LogicalOperator.AND);

            return filter.UserId.Equals(null)
                ? query
                : query.Where(compositePredicate);
        }
    }
}