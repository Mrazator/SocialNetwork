﻿using SocialNetworkBL.Facades.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Infrastructure.UnitOfWork;
using SocialNetworkBL.Services.GroupProfile;
using SocialNetworkBL.Services.GroupsUsers;
using SocialNetworkBL.Services.Posts;
using SocialNetworkBL.Services.Comments;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.GroupProfileDtos;
using SocialNetworkBL.Services.BasicUser;

namespace SocialNetworkBL.Facades
{
    public class GroupProfileFacade : FacadeBase
    {
        private readonly IGroupProfileService _groupProfileService;
        private readonly IGroupUserService _groupUserService;
        private readonly IGetGroupUsersService _getGroupUsersService;
        private readonly IGroupProfilePostsService _postService;
        private readonly IGroupProfileUserService _groupProfileUserService;
        private readonly ICommentService _commentService;
        private readonly IBasicUsersService _basicUsersService;


        public GroupProfileFacade(IUnitOfWorkProvider unitOfWorkProvider,
                                  IGroupProfileService groupProfileService,
                                  IGroupUserService groupUserService,
                                  IGetGroupUsersService getGroupUsersService,
                                  IGroupProfilePostsService postService,
                                  IGroupProfileUserService groupProfileUserService,
                                  IBasicUsersService basicUsersService,
                                  ICommentService commentService) 
            : base(unitOfWorkProvider)
        {
            _groupProfileService = groupProfileService;
            _groupUserService = groupUserService;
            _getGroupUsersService = getGroupUsersService;
            _postService = postService;
            _groupProfileUserService = groupProfileUserService;
            _commentService = commentService;
            _basicUsersService = basicUsersService;
        }

        public async Task<GroupProfileDto> GetGroupProfileAsync(int id)
        {
            using (UnitOfWorkProvider.Create())
            {
                var groupProfile = await _groupProfileService.GetGroupProfileAsync(id);

                groupProfile.Posts = await GetGroupPostsAsync(id);

                foreach (var post in groupProfile.Posts)
                {
                    if (!post.StayAnonymous)
                    {
                        post.User = await _groupProfileUserService.GetAsync((int)post.UserId);
                        var comments = await _commentService.GetCommentsByPostIdAsync(post.Id);

                        foreach (var comment in comments)
                        {
                            comment.NickName = (await _basicUsersService.GetAsync(comment.UserId)).NickName;
                        }

                        post.Comments = comments;
                    }
                }

                groupProfile.GroupUsers = await _getGroupUsersService.GetGroupProfileUsersAsync(id);

                return groupProfile;
            }
        }

        public async Task<IList<GroupProfilePostDto>> GetGroupPostsAsync(int groupId)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await _postService.GetGroupProfilePostsAsync(groupId);
            }
        }

        public async Task<int> PostInGroup(GroupProfilePostDto post)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var postId = _postService.Create(post);
                await uow.Commit();
                return postId;
            }
        }

        public async Task<int> AddComment(CommentDto comment)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var commentId = _commentService.Create(comment);
                await uow.Commit();
                return commentId;
            }
        }

        public async Task InviteUser(AddUserToGroupDto userToGroup)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                await _groupUserService.AddUserToGroupAsync(userToGroup, false);
                await uow.Commit();
            }
        }

        public async Task<IList<GroupProfileUserDto>> GetGroupProfileUsersByGroupIdAsync(int groupId)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await _getGroupUsersService.GetGroupProfileUsersAsync(groupId);
            }
        }

        public async Task<IEnumerable<GetGroupUsersDto>> GetGroupUsers(int groupId)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await _getGroupUsersService.GetGroupUsersAsync(groupId);
            }
        }

        #region AdminMethods

        public async Task RemoveUserFromGroup(int groupId, int userId)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var groupUser = await _groupUserService.GetGroupUserAsync(groupId, userId);
                _groupUserService.Delete(groupUser.Id);

                await uow.Commit();
            }
        }

        public async Task MakeUserAdminAsync(int groupId, int userId)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var groupUser = await _groupUserService.GetGroupUserAsync(groupId, userId);
                groupUser.IsAdmin = true;
                await _groupUserService.Update(groupUser);
                await uow.Commit();
            }
        }

        public async Task DeletePost(int postId)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var comments = await _commentService.GetCommentsByPostIdAsync(postId);

                while (!comments.IsNullOrEmpty())
                {
                    var comment = comments.First();
                    _commentService.Delete(comment.Id);
                    comments.Remove(comment);
                }

                _postService.Delete(postId);

                await uow.Commit();
            }
        }

        #endregion
    }
}
