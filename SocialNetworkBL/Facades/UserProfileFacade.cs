using System.Linq;
using System.Threading.Tasks;
using System.Web.UI;
using Infrastructure.UnitOfWork;
using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.DataTransferObjects.UserProfileDtos;
using SocialNetworkBL.Facades.Common;
using SocialNetworkBL.Services.BasicUser;
using SocialNetworkBL.Services.Comments;
using SocialNetworkBL.Services.Common;
using SocialNetworkBL.Services.Friendships;
using SocialNetworkBL.Services.Posts;
using SocialNetworkBL.Services.UserProfile;

namespace SocialNetworkBL.Facades
{
    public class UserProfileFacade : FacadeBase
    {
        private readonly IUserProfileUserService _userProfileUserService;
        private readonly IUserProfilePostService _userProfilePostService;
        private readonly ICommentService _commentService;
        private readonly IBasicUsersService _basicUsersService;
        private readonly IFriendshipService _friendshipService;


        public UserProfileFacade(IUnitOfWorkProvider unitOfWorkProvider,
            IUserProfileUserService userProfileUserService,
            IUserProfilePostService userProfilePostService,
            ICommentService commentService,
            IBasicUsersService basicUsersService,
            IFriendshipService friendshipService) : base(unitOfWorkProvider)
        {
            _userProfileUserService = userProfileUserService;
            _userProfilePostService = userProfilePostService;
            _commentService = commentService;
            _basicUsersService = basicUsersService;
            _friendshipService = friendshipService;
        }

        public async Task<UserProfileUserDto> GetUserProfile(PostFilterDto postFilter, CommentFilterDto commentFilter)
        {
            using (UnitOfWorkProvider.Create())
            {
                var user = await _userProfileUserService.GetUserProfileUserByIdAsync(postFilter.UserId);
                user.Friends = (await _friendshipService.GetFriendsByUserIdAsync(user.Id)).ToList();
                user.Posts = await GetPostsByFilters(postFilter, commentFilter);

                return user;
            }
        }

        //Get posts by filter, when is commentFilter not null then load comments
        public async Task<QueryResultDto<UserProfilePostDto, PostFilterDto>> GetPostsByFilters(PostFilterDto postFilter, CommentFilterDto commentFilter)
        {
            postFilter.SortCriteria = nameof(Post.PostedAt);
            var posts = await _userProfilePostService.GetPostsByFilterAsync(postFilter);

            if (commentFilter != null)
            {
                foreach (var post in posts.Items)
                {
                    commentFilter.PostId = post.Id;
                    post.Comments = await GetCommentsByFilter(commentFilter);
                }
            }

            return posts;
        }

        private async Task<QueryResultDto<CommentDto, CommentFilterDto>> GetCommentsByFilter(CommentFilterDto commentFilter)
        {
            commentFilter.SortCriteria = nameof(Comment.PostedAt);
            commentFilter.SortAscending = true;
            var comments = await _commentService.GetCommentsByFilter(commentFilter);

            foreach (var comment in comments.Items)
            {
                var user = await _basicUsersService.GetAsync(comment.UserId);
                comment.NickName = user.NickName;
            }

            return comments;
        }

        public async Task<int> AddPost(UserProfilePostDto post)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var postId = _userProfilePostService.Create(post);
                await uow.Commit();
                return postId;
            }
        }
    }
}