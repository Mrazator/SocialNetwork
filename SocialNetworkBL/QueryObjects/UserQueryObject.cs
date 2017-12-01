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
    public class UserQueryObject : QueryObjectBase<UserDto, User, UserFilterDto, IQuery<User>>
    {
        public UserQueryObject(IMapper mapper, IQuery<User> query) : base(mapper, query) { }

        protected override IQuery<User> ApplyWhereClause(IQuery<User> query, UserFilterDto filter)
        {
            var simplePredicate = string.IsNullOrEmpty(filter.NickName)  && 
                                    !string.IsNullOrEmpty(filter.SubName) ?
                                        new SimplePredicate(nameof(User.NickName), ValueComparingOperator.StringContains, filter.SubName) :
                                        new SimplePredicate(nameof(User.NickName), ValueComparingOperator.Equal, filter.NickName);

            return string.IsNullOrEmpty(filter.NickName) && string.IsNullOrEmpty(filter.SubName)
                ? query
                : query.Where(simplePredicate);

            //var simplePredicate = new SimplePredicate(nameof(User.NickName), ValueComparingOperator.StringContains, filter.SubName);

            //return filter.SubName == null
            //    ? query
            //    : query.Where(simplePredicate);
        }
    }
}
