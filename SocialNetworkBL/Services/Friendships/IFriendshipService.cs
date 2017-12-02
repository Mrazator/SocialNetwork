using System.Collections.Generic;
using System.Threading.Tasks;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Services.Common;

namespace SocialNetworkBL.Services.Friendships
{
    public interface IFriendshipService : IService<FriendshipDto, FriendshipFilterDto>
    {
        /// <summary>
        ///     Gets list of friends
        /// </summary>
        /// <param name="userId">Id of the user</param>
        /// <returns>list of friends</returns>
        Task<IList<int>> GetFriendsIdsByUserIdAsync(int userId);
    }
}