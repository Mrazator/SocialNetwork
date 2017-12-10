using AutoMapper;
using Infrastructure.Query;
using Infrastructure.Query.Predicates;
using Infrastructure.Query.Predicates.Operators;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.DataTransferObjects.GroupProfileDtos;
using SocialNetworkBL.QueryObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetworkDAL.Entities;

namespace SocialNetworkBL.QueryObjects.GroupProfileQueryObjects
{
    public class GroupProfileQueryObject : QueryObjectBase<GroupProfileDto, Group, GroupFilterDto, IQuery<Group>>
    {
        public GroupProfileQueryObject(IMapper mapper, IQuery<Group> query) : base(mapper, query)
        {
        }

        protected override IQuery<Group> ApplyWhereClause(IQuery<Group> query, GroupFilterDto filter)
        {
            var simplePredicate = new SimplePredicate(nameof(Group.Name), ValueComparingOperator.Equal, filter.GroupName);

            return string.IsNullOrEmpty(filter.GroupName)
                ? query
                : query.Where(simplePredicate);
        }
    }
}
