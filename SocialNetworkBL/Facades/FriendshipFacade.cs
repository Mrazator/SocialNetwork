using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.UnitOfWork;
using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Facades.Common;
using SocialNetworkBL.Services.Common;
using SocialNetworkBL.Services.Friendships;

namespace SocialNetworkBL.Facades
{
    public class FriendshipFacade : FacadeBase<Friendship, FriendshipDto, FriendshipFilterDto>
    {
        private readonly IFriendshipService _friendshipService;

        public FriendshipFacade(
            IUnitOfWorkProvider unitOfWorkProvider,
            CrudQueryServiceBase<Friendship, FriendshipDto, FriendshipFilterDto> service,
            IFriendshipService friendshipService
        ) : base(unitOfWorkProvider, service)
        {
            _friendshipService = friendshipService;
        }

        public async Task<IList<int>> GetFriendsIdsByUserIdAsync(int userId)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await _friendshipService.GetFriendsIdsByUserIdAsync(userId);
            }
        }
    }
}