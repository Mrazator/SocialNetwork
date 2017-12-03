﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Facades;
using SocialNetworkPL.Models;

namespace SocialNetworkPL.Controllers
{
    public class UsersController : Controller
    {
        public UserFacade UserFacade { get; set; }
        public PostFacade PostFacade { get; set; }
        public CommentFacade CommentFacade { get; set; }
        public FriendshipFacade FriendshipFacade { get; set; }
        public GroupFacade GroupFacade { get; set; }

        public async Task<ActionResult> Index([FromUri] string subname)
        {
            var filter = new UserFilterDto { SubName = subname };

            var users = await UserFacade.GetUsersContainingSubNameAsync(filter.SubName);
            var user = await UserFacade.GetUserByNickNameAsync(User.Identity.Name);


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
            UserDto user, authUser;
            List<PostDto> posts;
            List<int> friendships;
            List<UserDto> users;

            if (nickName != "")
            {
                try
                {
                    var usersQueryResultDto = await UserFacade.GetAllItemsAsync();
                    users = usersQueryResultDto.Items.ToList();
                    user = await UserFacade.GetUserByNickNameAsync(nickName);
                    authUser = await UserFacade.GetUserByNickNameAsync(User.Identity.Name);
                    posts = await PostFacade.GetPostsByUserIdAsync(user.Id) as List<PostDto>;
                    friendships = await FriendshipFacade.GetFriendsIdsByUserIdAsync(user.Id) as List<int>;
                }
                catch
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }

            return View("UserProfile", new UserProfileModel
            {
                UserProfileDto = user,
                PostDtos = posts,
                FriendsIds = friendships,
                Users = users,
                AuthenticatedUser = authUser
            });
        }

        public async Task<ActionResult> UserSettings(string nickName = "")
        {
            var user = await UserFacade.GetUserByNickNameAsync(nickName);

            return View("UserSettings", user);
        }

        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> SaveSettings(string profileDescription = "", string nickName = "")
        {
            var user = await UserFacade.GetUserByNickNameAsync(nickName);
            user.ProfileDescription = profileDescription;
            await UserFacade.UpdateAsync(user);

            return RedirectToAction("UserSettings", nickName);
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
                await UserFacade.CreateAsync(user);

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
                await UserFacade.UpdateAsync(user);

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
                await UserFacade.DeleteAsync(id);

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
                var newPost = new PostDto
                {
                    Text = model.NewPostText,
                    UserId = model.UserProfileDto.Id,
                    PostedAt = DateTime.Now.ToUniversalTime(),
                    StayAnonymous = model.StayAnonymous
                };

                await PostFacade.CreateAsync(newPost);
                return RedirectToAction("UserProfile", new { nickName = model.UserProfileDto.NickName });
            }
            catch
            {
                return RedirectToAction("UserProfile", new { nickName = model.UserProfileDto.NickName });
            }
        }

        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> AddFriend(int id)
        {
            var user = await UserFacade.GetUserByNickNameAsync(User.Identity.Name);

            var friendship = new FriendshipDto()
            {
                User1Id = user.Id,
                User2Id = id,
                FriendshipStart = DateTime.Now.ToUniversalTime(),
            };

            await FriendshipFacade.CreateAsync(friendship);
            return RedirectToAction("Index");
        }

        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> AcceptFriend(int friendId)
        {
            var user = await UserFacade.GetUserByNickNameAsync(User.Identity.Name);
            var friendship = user.AcceptedFriendships
                .FirstOrDefault(x => !x.IsAccepted && x.User1Id == friendId);

            if (friendship != null)
            {
                friendship.IsAccepted = true;

                await FriendshipFacade.UpdateAsync(friendship);
            }

            return RedirectToAction("Index");
        }

        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> AddComment(UserProfileModel model)
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
                return RedirectToAction("UserProfile", new { nickName = model.UserProfileDto.NickName });
            }
            catch
            {
                return RedirectToAction("UserProfile", new { nickName = model.UserProfileDto.NickName });
            }
        }
    }
}