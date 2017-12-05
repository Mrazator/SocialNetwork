using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Castle.Core.Internal;
using Infrastructure;
using Infrastructure.Query;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.DataTransferObjects.UserProfileDtos;
using SocialNetworkBL.QueryObjects.Common;
using SocialNetworkBL.Services.Common;
using SocialNetwork.Entities;

namespace SocialNetworkBL.Services.UserProfile
{
    public class UserProfileUserService : ServiceBase, IUserProfileUserService
    {
        private readonly QueryObjectBase<UserProfileUserDto, SocialNetwork.Entities.User, UserFilterDto, IQuery<SocialNetwork.Entities.User>> _userProfileUserQueryObject;
        private readonly IRepository<SocialNetwork.Entities.User> _repository;

        public UserProfileUserService(
            IMapper mapper,
            QueryObjectBase<UserProfileUserDto, SocialNetwork.Entities.User, UserFilterDto, IQuery<SocialNetwork.Entities.User>> userProfileUserQueryObject,
            IRepository<SocialNetwork.Entities.User> repository)
            : base(mapper)
        {
            this._userProfileUserQueryObject = userProfileUserQueryObject;
            this._repository = repository;
        }

        public async Task<UserProfileUserDto> GetUserProfileUserByIdAsync(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var entity = await _repository.GetAsync((int) id);
            return entity != null ? Mapper.Map<UserProfileUserDto>(entity) : null;
        }

        public async Task<UserProfileUserDto> GetUserProfileUserByNickNameAsync(string nickName)
        {
            var queryResult = await _userProfileUserQueryObject.ExecuteQuery(new UserFilterDto { NickName = nickName });
            return queryResult?.Items.SingleOrDefault();
        }
    }
}
