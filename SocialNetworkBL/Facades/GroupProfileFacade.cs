using SocialNetworkBL.Facades.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.UnitOfWork;
using SocialNetworkBL.Services.GroupProfile;
using SocialNetworkBL.Services.GroupsUsers;
using SocialNetworkBL.Services.Posts;
using SocialNetworkBL.Services.Comments;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.GroupProfileDtos;

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

        public GroupProfileFacade(IUnitOfWorkProvider unitOfWorkProvider,
                                  IGroupProfileService groupProfileService,
                                  IGroupUserService groupUserService,
                                  IGetGroupUsersService getGroupUsersService,
                                  IGroupProfilePostsService postService,
                                  IGroupProfileUserService groupProfileUserService,
                                  ICommentService commentService) 
            : base(unitOfWorkProvider)
        {
            _groupProfileService = groupProfileService;
            _groupUserService = groupUserService;
            _getGroupUsersService = getGroupUsersService;
            _postService = postService;
            _groupProfileUserService = groupProfileUserService;
            _commentService = commentService;
        }

        public async Task<GroupProfileDto> GetGroupProfileAsync(int id)
        {
            var groupProfile = await _groupProfileService.GetGroupProfileAsync(id);

            groupProfile.Posts = await GetGroupPostsAsync(id);

            foreach (var post in groupProfile.Posts)
            {
                if (!post.StayAnonymous)
                {
                    post.User = await _groupProfileUserService.GetAsync((int) post.UserId);
                    post.Comments = await _commentService.GetCommentsByPostIdAsync(post.Id);
                }
            }

            groupProfile.GroupUsers = await _getGroupUsersService.GetGroupUsersAsync(id);

            return groupProfile;
            
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

        #region AdminMethods

        public async void RemoveUserFromGroup(int groupId, int userId)
        {
            using (UnitOfWorkProvider.Create())
            {
                var groupUser = await _groupUserService.GetGroupUserAsync(groupId, userId);
                _groupUserService.Delete(groupUser.Id);
            }
        }

        public async Task MakeUserAdminAsync(int groupId, int userId)
        {
            using (UnitOfWorkProvider.Create())
            {
                var groupUser = await _groupUserService.GetGroupUserAsync(groupId, userId);
                groupUser.IsAdmin = true;
                await _groupUserService.Update(groupUser);
            }
        }

        #endregion
    }
}
