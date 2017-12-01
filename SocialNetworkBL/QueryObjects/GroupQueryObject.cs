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
    public class GroupQueryObject : QueryObjectBase<GroupDto, Group, GroupFilterDto, IQuery<Group>>
    {
        public GroupQueryObject(IMapper mapper, IQuery<Group> query) : base(mapper, query)
        {
        }

        protected override IQuery<Group> ApplyWhereClause(IQuery<Group> query, GroupFilterDto filter)
        {
            var simplePredicate =
                new SimplePredicate(nameof(Group.Name), ValueComparingOperator.StringContains, filter.SubName);

            return filter.SubName.Equals("")
                ? query
                : query.Where(simplePredicate);
        }
    }
}