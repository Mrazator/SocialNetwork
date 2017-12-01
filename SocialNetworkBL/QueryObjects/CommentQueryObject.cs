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
    public class CommentQueryObject : QueryObjectBase<CommentDto, Comment, CommentFilterDto, IQuery<Comment>>
    {
        public CommentQueryObject(IMapper mapper, IQuery<Comment> query) : base(mapper, query)
        {
        }

        protected override IQuery<Comment> ApplyWhereClause(IQuery<Comment> query, CommentFilterDto filter)
        {
            var simplePredicate =
                new SimplePredicate(nameof(Comment.PostId), ValueComparingOperator.Equal, filter.PostId);

            return filter.PostId.Equals(null)
                ? query
                : query.Where(simplePredicate);
        }
    }
}