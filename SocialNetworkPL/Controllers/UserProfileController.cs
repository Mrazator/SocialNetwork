using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.DataTransferObjects.UserProfileDtos;
using SocialNetworkBL.Facades;
using SocialNetworkPL.Models;

namespace SocialNetworkPL.Controllers
{
    //tento controller je cely prepsany
    //tak aby vyzuival nove vytvorenou UserProfileFacade, nove Dtocka, QueryObjekty, Servisy...
    public class UserProfileController : Controller
    {
        //zatim se zobrazuje jen 250 prvnich postu a 50 prvnich komentaru
        public const int Posts = 250;
        public const int Comments = 50;

        private const string PostFilterSessionKey = "postFilter";
        private const string CommentFilterSessionKey = "commentFilter";

        public UserProfileFacade UserProfileFacade { get; set; }
        public BasicUserFacade BasicUserFacade { get; set; }

        //pouze pripraveno na pagination, cele to vsak chci zkusit prepsat do dotVVM, ale neni moc casu :)
        public async Task<ActionResult> Index(string nickName = "", int postPage = 1, int commentPage = 1)
        {
            //delete this after Identity.UserId is set
            var user = await BasicUserFacade.GetUserByNickNameAsync(nickName);

            var postFilter = Session[PostFilterSessionKey] as PostFilterDto ?? new PostFilterDto() { PageSize = Posts};
            postFilter.RequestedPageNumber = postPage;
            postFilter.UserId = user.Id;

            var commentFilter = Session[CommentFilterSessionKey] as CommentFilterDto ?? new CommentFilterDto() { PageSize = Comments };
            commentFilter.RequestedPageNumber = commentPage;

            var userDto = await UserProfileFacade.GetUserProfile(postFilter, commentFilter);
            var authUser = await BasicUserFacade.GetUserByNickNameAsync(User.Identity.Name);


            return View("UserProfile", new UserProfileModel
            {
                UserProfileUser = userDto,
                AuthenticatedUser = authUser,
                PostFilter = postFilter,
                CommentFilter = commentFilter
            });
        }

        [HttpPost]
        public async Task<ActionResult> AddPost(UserProfileModel model)
        {
            try
            {
                await UserProfileFacade.AddPost(new UserProfilePostDto()
                {
                    PostedAt = DateTime.Now.ToUniversalTime(),
                    StayAnonymous = model.PostStayAnonymous,
                    UserId = model.UserProfileUser.Id,
                    Text = model.NewPostText
                });

                return RedirectToAction("Index", new { nickName = model.UserProfileUser.NickName });
            }
            catch
            {
                return RedirectToAction("Index", new { nickName = model.UserProfileUser.NickName });
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddComment(UserProfileModel model)
        {
            try
            {
                await UserProfileFacade.AddComment(new CommentDto
                {
                    Text = model.NewCommentText,
                    PostedAt = DateTime.Now.ToUniversalTime(),
                    StayAnonymous = model.PostStayAnonymous,
                    UserId = model.AuthenticatedUser.Id,
                    PostId = model.PostId
                });

                return RedirectToAction("Index", new { nickName = model.UserProfileUser.NickName });
            }
            catch
            {
                return RedirectToAction("Index", new { nickName = model.UserProfileUser.NickName });
            }
        }

        public async Task<ActionResult> UserSettings(string nickName = "")
        {
            var user = await BasicUserFacade.GetUserByNickNameAsync(nickName);

            return View("UserSettings", new SetingsModel
            {
                NickName = user.NickName,
                Description = user.Description
            });
        }

        [HttpPost]
        public async Task<ActionResult> SaveSettings(SetingsModel model)
        {
            var user = await BasicUserFacade.GetUserByNickNameAsync(model.NickName);
            user.Description = model.Description;
            await BasicUserFacade.UpdateAsync(user);

            return RedirectToAction("Index", "UserProfile", new { model.NickName });
        }
    }
}