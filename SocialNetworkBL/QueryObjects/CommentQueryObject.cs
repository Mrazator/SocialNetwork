using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.QueryObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Query;
using SocialNetworkBL.DataTransferObjects;
using AutoMapper;
using Infrastructure.Query.Predicates;
using Infrastructure.Query.Predicates.Operators;

namespace SocialNetworkBL.QueryObjects
{
    public class CommentQueryObject : QueryObjectBase<CommentDto, Comment, CommentFilterDto, IQuery<Comment>>
    {
        public CommentQueryObject(IMapper mapper, IQuery<Comment> query) : base(mapper, query) { }

        protected override IQuery<Comment> ApplyWhereClause(IQuery<Comment> query, CommentFilterDto filter)
        {
            var simplePredicate = new SimplePredicate(nameof(Comment.PostId), ValueComparingOperator.Equal, filter.PostId);

            return filter.PostId.Equals(null)
                ? query
                : query.Where(simplePredicate);
        }
    }
}
