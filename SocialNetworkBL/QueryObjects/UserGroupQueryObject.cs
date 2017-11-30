using AutoMapper;
using Infrastructure.Query;
using Infrastructure.Query.Predicates;
using Infrastructure.Query.Predicates.Operators;
using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.QueryObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBL.QueryObjects
{
    public class UserGroupQueryObject : QueryObjectBase<UserGroupDto, GroupUser , UserGroupFilterDto, IQuery<GroupUser>>
    {
        public UserGroupQueryObject(IMapper mapper, IQuery<GroupUser> query) : base(mapper, query) { }

        protected override IQuery<GroupUser> ApplyWhereClause(IQuery<GroupUser> query, UserGroupFilterDto filter)
        {
            var simplePredicate = new SimplePredicate(nameof(GroupUser.GroupId), ValueComparingOperator.Equal, filter.UserId);

            return filter.UserId.Equals(null)
                ? query
                : query.Where(simplePredicate);
        }
    }
}
