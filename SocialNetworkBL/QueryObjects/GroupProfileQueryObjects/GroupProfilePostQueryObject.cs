using AutoMapper;
using Infrastructure.Query;
using Infrastructure.Query.Predicates;
using Infrastructure.Query.Predicates.Operators;
using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.DataTransferObjects.GroupProfileDtos;
using SocialNetworkBL.QueryObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBL.QueryObjects.GroupProfileQueryObjects
{
    public class GroupProfilePostQueryObject : QueryObjectBase<GroupProfilePostDto, Post, PostFilterDto, IQuery<Post>>
    {
        public GroupProfilePostQueryObject(IMapper mapper, IQuery<Post> query) : base(mapper, query)
        {
        }

        protected override IQuery<Post> ApplyWhereClause(IQuery<Post> query, PostFilterDto filter)
        {
            var simplePredicate = new SimplePredicate(nameof(Post.GroupId), ValueComparingOperator.Equal, filter.GroupId);

            return query.Where(simplePredicate);
        }
    }
}
