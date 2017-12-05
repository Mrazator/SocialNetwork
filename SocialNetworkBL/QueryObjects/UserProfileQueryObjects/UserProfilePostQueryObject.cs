using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure.Query;
using Infrastructure.Query.Predicates;
using Infrastructure.Query.Predicates.Operators;
using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.DataTransferObjects.UserProfileDtos;
using SocialNetworkBL.QueryObjects.Common;

namespace SocialNetworkBL.QueryObjects.UserProfileQueryObjects
{
    public class UserProfilePostQueryObject : QueryObjectBase<UserProfilePostDto, Post, PostFilterDto, IQuery<Post>>
    {
        public UserProfilePostQueryObject(IMapper mapper, IQuery<Post> query) : base(mapper, query)
        {
        }

        protected override IQuery<Post> ApplyWhereClause(IQuery<Post> query, PostFilterDto filter)
        {
            var simplePredicate = filter.GroupId.Equals(null)
                ? new SimplePredicate(nameof(Post.UserId), ValueComparingOperator.Equal, filter.UserId)
                : new SimplePredicate(nameof(Post.GroupId), ValueComparingOperator.Equal, filter.GroupId);

            return filter.UserId.Equals(null) && filter.GroupId.Equals(null)
                ? query
                : query.Where(simplePredicate);
        }
    }
}
