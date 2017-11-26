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
    public class GroupQueryObject : QueryObjectBase<GroupDto, Group, GroupFilterDto, IQuery<Group>>
    {
        public GroupQueryObject(IMapper mapper, IQuery<Group> query) : base(mapper, query) { }

        protected override IQuery<Group> ApplyWhereClause(IQuery<Group> query, GroupFilterDto filter)
        {
            var simplePredicate = new SimplePredicate(nameof(Group.Name), ValueComparingOperator.StringContains, filter.SubName);

            return filter.SubName.Equals("")
                ? query
                : query.Where(simplePredicate);
        }
    }
}
