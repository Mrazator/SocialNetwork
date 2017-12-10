using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using Infrastructure.UnitOfWork;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Facades.Common;
using SocialNetworkBL.Services.BasicUser;
using SocialNetworkBL.Services.Friendships;
using SocialNetworkBL.Services.GroupsUsers;

namespace SocialNetworkBL.Facades
{
    public class BasicUserFacade : FacadeBase
    {
        private readonly IBasicUsersService _basicUsersService;
        private readonly IFriendshipService _friendshipService;
        private readonly IGetUserGroupsService _getUserGroupsService;



        public BasicUserFacade(
            IUnitOfWorkProvider unitOfWorkProvider,
            IBasicUsersService basicUsersService,
            IFriendshipService friendshipService,
            IGetUserGroupsService getUserGroupsService
            ) : base(unitOfWorkProvider)
        {
            _basicUsersService = basicUsersService;
            _friendshipService = friendshipService;
            _getUserGroupsService = getUserGroupsService;
        }

        public async Task UpdateAsync(BasicUserDto model)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                await _basicUsersService.Update(model);
                await uow.Commit();
            }
        } 

        public async Task<BasicUserDto> GetUserByNickNameAsync(string nickName)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await _basicUsersService.GetUserByNickName(nickName);
            }
        }

        public async Task<IEnumerable<BasicUserDto>> GetUsersBySubnameAsync(string subname)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await _basicUsersService.GetUsersContainingSubNameAsync(subname);
            }
        }

        public async Task<QueryResultDto<BasicUserDto, UserFilterDto>> GetQueryResultUsersByFilter(UserFilterDto filter)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await _basicUsersService.GetUsersQueryContainingSubNameAsync(filter);
            }
        }

        public async Task<BasicUserDto> GetBasicUserWithFriends(int userId)
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

        public async Task<BasicUserDto> GetBasicUserWithGroups(int userId)
        {
            using (UnitOfWorkProvider.Create())
            {
                var groups = await _getUserGroupsService.GetGroupsByUserIdAsync(userId, true);
                var groupsInvitedInto = await _getUserGroupsService.GetGroupsByUserIdAsync(userId, false);
                var user = await _basicUsersService.GetAsync(userId);

                var groupDtos = groups.ToList();
                groupDtos.AddRange(groupsInvitedInto);

                user.Groups = groupDtos;

                return user;
            }
        }

        public async Task AssignGroupsToUserAsync(BasicUserDto user)
        {
            using (UnitOfWorkProvider.Create())
            {
                var groups = await _getUserGroupsService.GetGroupsByUserIdAsync(user.Id, true);
                var groupsInvitedInto = await _getUserGroupsService.GetGroupsByUserIdAsync(user.Id, false);

                var groupDtos = groups.ToList();
                groupDtos.AddRange(groupsInvitedInto);

                user.Groups = groupDtos;
            }
        }
    }
}
