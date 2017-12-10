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

namespace SocialNetworkBL.Services.UserProfile
{
    public class UserProfileUserService : ServiceBase, IUserProfileUserService
    {
        private readonly QueryObjectBase<UserProfileUserDto, SocialNetworkDAL.Entities.User, UserFilterDto, IQuery<SocialNetworkDAL.Entities.User>> _userProfileUserQueryObject;
        private readonly IRepository<SocialNetworkDAL.Entities.User> _repository;

        public UserProfileUserService(
            IMapper mapper,
            QueryObjectBase<UserProfileUserDto, SocialNetworkDAL.Entities.User, UserFilterDto, IQuery<SocialNetworkDAL.Entities.User>> userProfileUserQueryObject,
            IRepository<SocialNetworkDAL.Entities.User> repository)
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
