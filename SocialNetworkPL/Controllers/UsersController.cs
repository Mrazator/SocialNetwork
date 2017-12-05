using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.DataTransferObjects.UserProfileDtos;
using SocialNetworkBL.Facades;
using SocialNetworkPL.Models;

namespace SocialNetworkPL.Controllers
{
    public class UsersController : Controller
    {
        public UserGenericFacade UserGenericFacade { get; set; }
        public PostGenericFacade PostGenericFacade { get; set; }
        public CommentGenericFacade CommentGenericFacade { get; set; }
        public FriendshipGenericFacade FriendshipGenericFacade { get; set; }
        public GroupGenericFacade GroupGenericFacade { get; set; }
        public UserProfileFacade UserProfileFacade { get; set; }
        public BasicUserFacade BasicUserFacade { get; set; }

        public async Task<ActionResult> Index([FromUri] string subname)
        {
            var filter = new UserFilterDto { SubName = subname };

            var users = await UserGenericFacade.GetUsersContainingSubNameAsync(filter.SubName);
            var user = await UserGenericFacade.GetUserByNickNameAsync(User.Identity.Name);


            var model = InitializeProductListViewModel(filter, users, user);

            return View("FriendManagementView", model);
        }

        private FindUsersModel InitializeProductListViewModel(UserFilterDto filter, IEnumerable<UserDto> users, UserDto user)
        {
            return new FindUsersModel
            {
                Filter = filter,
                Users = new HashSet<UserDto>(users),
                User = user
            };
        }

        public async Task<ActionResult> UserProfile(string nickName = "")
        {
            //new
            UserProfileUserDto userDto;
            BasicUserDto authUser;


            //old
            UserDto user;

            try
            {
                //old
                user = await UserGenericFacade.GetUserByNickNameAsync(nickName);

                //new
                userDto = await UserProfileFacade.GetUserProfile(new PostFilterDto() { UserId = user.Id }, new CommentFilterDto() { PageSize = 3 });
                authUser = await BasicUserFacade.GetUsersByNickName(User.Identity.Name);
            }
            catch
            {
                return RedirectToAction("Index");
            }

            return View("UserProfile", new UserProfileModel
            {
                //new
                UserProfileUser = userDto,
                AuthenticatedUser = authUser
            });
        }

        public async Task<ActionResult> UserSettings(string nickName = "")
        {
            var user = await UserGenericFacade.GetUserByNickNameAsync(nickName);

            return View("UserSettings", new SetingsModel
            {
                NickName = user.NickName,
                ProfileDescription = user.ProfileDescription
            });
        }

        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> SaveSettings(SetingsModel model)
        {
            var user = await UserGenericFacade.GetUserByNickNameAsync(model.NickName);
            user.ProfileDescription = model.ProfileDescription;
            await UserGenericFacade.UpdateAsync(user);

            return RedirectToAction("UserSettings", "Users", new { model.NickName });
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> Create(UserDto user)
        {
            try
            {
                await UserGenericFacade.CreateAsync(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Users/Edit/5
        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> Edit(int id, UserDto user)
        {
            try
            {
                await UserGenericFacade.UpdateAsync(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                await UserGenericFacade.DeleteAsync(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AddPost()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
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

                return RedirectToAction("UserProfile", new { nickName = model.UserProfileUser.NickName });
            }
            catch
            {
                return RedirectToAction("UserProfile", new { nickName = model.UserProfileUser.NickName });
            }
        }

        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> AddFriend(int id)
        {
            var user = await UserGenericFacade.GetUserByNickNameAsync(User.Identity.Name);

            var friendship = new FriendshipDto
            {
                User1Id = user.Id,
                User2Id = id,
                FriendshipStart = DateTime.Now.ToUniversalTime()
            };

            await FriendshipGenericFacade.CreateAsync(friendship);
            return RedirectToAction("Index");
        }

        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> AcceptFriend(int friendId)
        {
            var user = await UserGenericFacade.GetUserByNickNameAsync(User.Identity.Name);
            var friendship = user.AcceptedFriendships
                .FirstOrDefault(x => !x.IsAccepted && x.User1Id == friendId);

            if (friendship != null)
            {
                friendship.IsAccepted = true;

                await FriendshipGenericFacade.UpdateAsync(friendship);
            }

            return RedirectToAction("Index");
        }

        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> AddComment(UserProfileModel model)
        {
            try
            {
                var newComment = new CommentDto
                {
                    Text = model.NewCommentText,
                    PostedAt = DateTime.Now.ToUniversalTime(),
                    StayAnonymous = model.PostStayAnonymous,
                    UserId = model.AuthenticatedUser.Id,
                    PostId = model.PostId
                };

                await CommentGenericFacade.CreateAsync(newComment);
                return RedirectToAction("UserProfile", new { nickName = model.UserProfileUser.NickName });
            }
            catch
            {
                return RedirectToAction("UserProfile", new { nickName = model.UserProfileUser.NickName });
            }
        }
    }
}