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
    public class MessageQueryObject : QueryObjectBase<MessageDto, Message, MessageFilterDto, IQuery<Message>>
    {
        public MessageQueryObject(IMapper mapper, IQuery<Message> query) : base(mapper, query)
        {
        }

        protected override IQuery<Message> ApplyWhereClause(IQuery<Message> query, MessageFilterDto filter)
        {
            var simplePredicate = new SimplePredicate(nameof(Message.FriendshipId), ValueComparingOperator.Equal,
                filter.FriendshipId);

            return filter.FriendshipId.Equals(null)
                ? query
                : query.Where(simplePredicate);
        }
    }
}