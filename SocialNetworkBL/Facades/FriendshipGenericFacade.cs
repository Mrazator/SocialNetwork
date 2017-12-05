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
    public class FriendshipGenericFacade : GenericFacadeBase<Friendship, FriendshipDto, FriendshipFilterDto>
    {
        private readonly IFriendshipService _friendshipService;

        public FriendshipGenericFacade(
            IUnitOfWorkProvider unitOfWorkProvider,
            CrudQueryServiceBase<Friendship, FriendshipDto, FriendshipFilterDto> service,
            IFriendshipService friendshipService
        ) : base(unitOfWorkProvider, service)
        {
            _friendshipService = friendshipService;
        }

        public async Task<IEnumerable<BasicUserDto>> GetFriendsByUserIdAsync(int userId, bool isAccepted = false)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await _friendshipService.GetFriendsByUserIdAsync(userId ,isAccepted);
            }
        }

        public async Task<IEnumerable<FriendshipDto>> GetFriendshipsByUserIdAsync(int userId, bool isAccepted = false)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await _friendshipService.GetFriendshipsByUserIdAsync(userId, isAccepted);
            }
        }
    }
}