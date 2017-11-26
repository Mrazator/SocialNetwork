using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.UnitOfWork;
using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Facades.Common;
using SocialNetworkBL.Services.Common;
using SocialNetworkBL.Services.Users;

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
        ///     Gets users according to SubName
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