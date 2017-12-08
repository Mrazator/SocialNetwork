using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.GroupProfileDtos;
using SocialNetworkBL.Facades;
using SocialNetworkPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SocialNetworkPL.Controllers
{
    public class GroupProfileController : Controller
    {
        public GroupProfileFacade GroupProfileFacade { get; set; }
        public BasicUserFacade BasicUserFacade { get; set; }

        // GET: GroupProfile
        public async Task<ActionResult> Index(int groupId)
        {
            var groupProfile = await GroupProfileFacade.GetGroupProfileAsync(groupId);
            var authUser = await BasicUserFacade.GetUserByNickNameAsync(User.Identity.Name);

            return View("GroupProfile", new GroupProfileModel
            {
                GroupProfile = groupProfile,
                AuthenticatedUser = authUser
            });
        }

        [HttpPost]
        public async Task<ActionResult> PostInGroup(GroupProfileModel model)
        {
            try
            {
                var authUser = await BasicUserFacade.GetUserByNickNameAsync(User.Identity.Name);

                var post = new GroupProfilePostDto() 
                {
                    PostedAt = DateTime.Now.ToUniversalTime(),
                    StayAnonymous = model.PostStayAnonymous,
                    GroupId = model.GroupProfile.Id,
                    Text = model.NewPostText
                };
                if (!post.StayAnonymous)
                {
                    post.UserId = authUser.Id;
                }
                await GroupProfileFacade.PostInGroup(post);

                return RedirectToAction("Index", new { groupId = model.GroupProfile.Id });
            }
            catch
            {
                return RedirectToAction("Index", new { groupId = model.GroupProfile.Id });
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddComment(GroupProfileModel model)
        {
            try
            {
                var comment = new CommentDto
                {
                    Text = model.NewCommentText,
                    PostedAt = DateTime.Now.ToUniversalTime(),
                    UserId = model.AuthenticatedUser.Id,
                    PostId = model.PostId
                };

                await GroupProfileFacade.AddComment(comment);

                return RedirectToAction("Index", new { groupId = model.GroupProfile.Id });
            }
            catch
            {
                return RedirectToAction("Index", new { groupId = model.GroupProfile.Id });
            }
        }
    }
}