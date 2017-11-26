using Infrastructure.Query;
using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.QueryObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Query.Predicates;
using Infrastructure.Query.Predicates.Operators;

namespace SocialNetworkBL.QueryObjects
{
    public class PostQueryObject : QueryObjectBase<PostDto, Post, PostFilterDto, IQuery<Post>>
    {
        public PostQueryObject(IMapper mapper, IQuery<Post> query) : base(mapper, query) { }

        protected override IQuery<Post> ApplyWhereClause(IQuery<Post> query, PostFilterDto filter)
        {
            var simplePredicate = filter.GroupId.Equals(null) ?
                                        new SimplePredicate(nameof(Post.UserId), ValueComparingOperator.Equal, filter.UserId) :
                                        new SimplePredicate(nameof(Post.GroupId), ValueComparingOperator.Equal, filter.GroupId);

            return filter.UserId.Equals(null) && filter.GroupId.Equals(null)
                ? query
                : query.Where(simplePredicate);
        }
    }
}
