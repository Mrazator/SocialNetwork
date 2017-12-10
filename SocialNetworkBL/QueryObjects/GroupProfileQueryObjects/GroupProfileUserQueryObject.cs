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
    public class GroupProfileUserQueryObject : QueryObjectBase<GroupProfileUserDto, User, UserFilterDto, IQuery<User>>
    {
        public GroupProfileUserQueryObject(IMapper mapper, IQuery<User> query) : base(mapper, query)
        {
        }

        protected override IQuery<User> ApplyWhereClause(IQuery<User> query, UserFilterDto filter)
        {
            var simplePredicate = new SimplePredicate(nameof(User.NickName), ValueComparingOperator.Equal, filter.NickName);

            return query.Where(simplePredicate);
        }
    }
}
