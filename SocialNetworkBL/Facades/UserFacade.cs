using SocialNetworkBL.Facades.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.UnitOfWork;
using SocialNetworkBL.Services.Users;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Services.Common;
using SocialNetwork.Entities;
using SocialNetworkBL.Services.Friendships;
using User = SocialNetwork.Entities.User;

namespace SocialNetworkBL.Facades
{
    public class UserFacade : FacadeBase<User, UserDto, UserFilterDto>
    {
        private readonly IUserService _userService;

        public UserFacade(
            IUnitOfWorkProvider unitOfWorkProvider,
            CrudQueryServiceBase<User, UserDto, UserFilterDto> service,
            IUserService userService
            ) : base(unitOfWorkProvider, service)
        {
            _userService = userService;
        }

        /// <summary>
        /// Gets users according to SubName
        /// </summary>
        /// <param name="subName"></param>
        /// <returns>Users containing subName</returns>
        public async Task<IEnumerable<UserDto>> GetUsersContainingSubNameAsync(string subName)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await _userService.GetUsersContainingSubNameAsync(subName);
            }
        }
    }
}
