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
    public class GroupUserQueryObject : QueryObjectBase<GroupUserDto, GroupUser, GroupUserFilterDto, IQuery<GroupUser>>
    {
        public GroupUserQueryObject(IMapper mapper, IQuery<GroupUser> query) : base(mapper, query) { }

        protected override IQuery<GroupUser> ApplyWhereClause(IQuery<GroupUser> query, GroupUserFilterDto filter)
        {
            var simplePredicate = filter.GroupId.Equals(null) ?
                                        new SimplePredicate(nameof(GroupUser.UserId), ValueComparingOperator.Equal, filter.UserId) :
                                        new SimplePredicate(nameof(GroupUser.GroupId), ValueComparingOperator.Equal, filter.GroupId);

            return filter.UserId.Equals(null) && filter.GroupId.Equals(null)
                ? query
                : query.Where(simplePredicate);
        }
    }
}
