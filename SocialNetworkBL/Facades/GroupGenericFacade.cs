﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.UnitOfWork;
using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Facades.Common;
using SocialNetworkBL.Services.Common;
using SocialNetworkBL.Services.Groups;
using SocialNetworkBL.Services.GroupsUsers;
using SocialNetworkBL.Services.Posts;

namespace SocialNetworkBL.Facades
{
    public class GroupGenericFacade : GenericFacadeBase<Group, GroupDto, GroupFilterDto>
    {
        private readonly IGroupService _groupService;
        private readonly IGroupUserService _groupUserService;
        private readonly IGetGroupUsersService _getGroupUsersService;
        private readonly IPostService _postService;

        public GroupGenericFacade(
            IUnitOfWorkProvider unitOfWorkProvider,
            CrudQueryServiceBase<Group, GroupDto, GroupFilterDto> service,
            IGroupService groupService,
            IGroupUserService groupUserService,
            IGetGroupUsersService getGroupUsersService,
            IPostService postService
        ) : base(unitOfWorkProvider, service)
        {
            _groupService = groupService;
            _groupUserService = groupUserService;
            _getGroupUsersService = getGroupUsersService;
            _postService = postService;
        }

        public async Task<IList<GroupDto>> GetGroupsContainingSubNameAsync(string subName)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await _groupService.GetGroupsContainingSubNameAsync(subName);
            }
        }

        public async Task<int> CreateGroup(GroupCreateDto groupDto, AddUserToGroupDto userToGroup)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var groupId = await _groupService.CreateGroupAsync(groupDto);
                userToGroup.GroupId = groupId;
                await _groupUserService.AddUserToGroupAsync(userToGroup, true);
                await uow.Commit();
                return groupId;
            }
        }
        
        public async Task<int> AddUserAsync(AddUserToGroupDto userToGroup)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var groupId = await _groupUserService.AddUserToGroupAsync(userToGroup, false);
                await uow.Commit();
                return groupId;
            }
        }
    }
}