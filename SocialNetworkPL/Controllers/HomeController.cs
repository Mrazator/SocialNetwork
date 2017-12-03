using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Facades;
using SocialNetworkPL.Models;

namespace SocialNetworkPL.Controllers
{
    public class HomeController : Controller
    {
        public PostFacade PostFacade { get; set; }
        public UserFacade UserFacade { get; set; }
        public CommentFacade CommentFacade { get; set; }

        // GET: Posts
        public async Task<ActionResult> Index(int page = 1)
        {
            var filter = new PostFilterDto();

            var result = await PostFacade.GetPostsAsync(filter);
            var user = await UserFacade.GetUserByNickNameAsync(User.Identity.Name);
            var users = await UserFacade.GetAllItemsAsync();
            var model = InitializeProductListViewModel(result, user, users.Items);

            return View("Index", model);
        }

        private PostListModel InitializeProductListViewModel(QueryResultDto<PostDto, PostFilterDto> result, UserDto user, IEnumerable<UserDto> users)
        {
            return new PostListModel
            {
                Posts = result.Items.OrderByDescending(x => x.PostedAt),
                Filter = result.Filter,
                AuthenticatedUser = user,
                Users = users
            };
        }

        // GET: Posts/UserProfile/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await PostFacade.GetAsync(id);
            return View("PostDetailView", model);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        [HttpPost]
        public async Task<ActionResult> Create(PostDto post)
        {
            try
            {
                await PostFacade.CreateAsync(post);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Posts/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, PostDto post)
        {
            try
            {
                await PostFacade.UpdateAsync(post);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Posts/Delete/5
        [HttpPost]
        public async Task<ActionResult> DeletePost(int id)
        {
            try
            {
                await PostFacade.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddComment(PostListModel model)
        {
            try
            {
                var newComment = new CommentDto()
                {
                    Text = model.CommentText,
                    PostedAt = DateTime.Now.ToUniversalTime(),
                    StayAnonymous = model.StayAnonymous,
                    UserId = model.AuthenticatedUser.Id,
                    PostId = model.PostId
                };

                await CommentFacade.CreateAsync(newComment);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}