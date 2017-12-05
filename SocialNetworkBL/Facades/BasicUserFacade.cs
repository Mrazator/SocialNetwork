using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using Infrastructure.UnitOfWork;
using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.Facades.Common;
using SocialNetworkBL.Services.BasicUser;
using SocialNetworkBL.Services.Friendships;

namespace SocialNetworkBL.Facades
{
    public class BasicUserFacade : FacadeBase
    {
        private readonly IBasicUsersService _basicUsersService;
        private readonly IFriendshipService _friendshipService;

        public BasicUserFacade(
            IUnitOfWorkProvider unitOfWorkProvider,
            IBasicUsersService basicUsersService,
            IFriendshipService friendshipService
            ) : base(unitOfWorkProvider)
        {
            _basicUsersService = basicUsersService;
            _friendshipService = friendshipService;
        }

        public async Task UpdateAsync(BasicUserDto model)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                await _basicUsersService.Update(model);
                await uow.Commit();
            }
        } 

        public async Task<BasicUserDto> GetUsersByNickNameAsync(string nickName)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await _basicUsersService.GetUsersByNickName(nickName);
            }
        }

        public async Task<IEnumerable<BasicUserDto>> GetUsersBySubnameAsync(string subname)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await _basicUsersService.GetUsersContainingSubNameAsync(subname);
            }
        }

        public async Task<BasicUserDto> GetBasicUserWithFriends(int userId, bool isAccepted = false)
        {
            using (UnitOfWorkProvider.Create())
            {
                var friendships = await _friendshipService.GetFriendshipsByUserIdAsync(userId, true);
                var friendshipsNotYet = await _friendshipService.GetFriendshipsByUserIdAsync(userId, false);
                var user = await _basicUsersService.GetAsync(userId);

                var friendshipDtos = friendships.ToList();
                friendshipDtos.AddRange(friendshipsNotYet);

                user.Friends = friendshipDtos;

                return user;
            }
        }
    }
}
