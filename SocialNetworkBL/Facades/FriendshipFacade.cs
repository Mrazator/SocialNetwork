using SocialNetworkBL.Facades.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.UnitOfWork;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetwork.Entities;
using SocialNetworkBL.Services.Common;
using SocialNetworkBL.Services.Friendships;
using SocialNetworkBL.Services.Messages;
using Friendship = SocialNetwork.Entities.Friendship;

namespace SocialNetworkBL.Facades
{
    public class FriendshipFacade : FacadeBase<Friendship, FriendshipDto, FriendshipFilterDto>
    {
        private readonly IFriendshipService _friendshipService;

        protected FriendshipFacade(
            IUnitOfWorkProvider unitOfWorkProvider,
            CrudQueryServiceBase<Friendship, FriendshipDto, FriendshipFilterDto> service,
            IFriendshipService friendshipService
            ) : base(unitOfWorkProvider, service)
        {
            _friendshipService = friendshipService;
        }

        public async Task<IList<UserDto>> GetFriendsByUserIdAsync(int userId)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await _friendshipService.GetFriendsByUserIdAsync(userId);
            }
        }
    }
}
