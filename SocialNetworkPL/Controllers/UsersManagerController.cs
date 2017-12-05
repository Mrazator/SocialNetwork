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
    public class UsersManagerController : Controller
    {
        //public UserGenericFacade UserGenericFacade { get; set; }
        public FriendshipGenericFacade FriendshipGenericFacade { get; set; }
        public BasicUserFacade BasicUserFacade { get; set; }

        public async Task<ActionResult> Index([FromUri] string subname)
        {
            var filter = new UserFilterDto { SubName = subname };

            var users = await BasicUserFacade.GetUsersBySubnameAsync(filter.SubName);
            var user = await BasicUserFacade.GetUsersByNickNameAsync(User.Identity.Name);

            var model = InitializeProductListViewModel(filter, users, user);

            return View("FriendManagementView", model);
        }

        private FindUsersModel InitializeProductListViewModel(UserFilterDto filter, IEnumerable<BasicUserDto> users,
            BasicUserDto user)
        {
            return new FindUsersModel
            {
                Filter = filter,
                Users = new HashSet<BasicUserDto>(users),
                User = user
            };
        }

        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> AddFriend(int id)
        {
            var user = await BasicUserFacade.GetUsersByNickNameAsync(User.Identity.Name);

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
            var user = await BasicUserFacade.GetUsersByNickNameAsync(User.Identity.Name);
            var authUser = await BasicUserFacade.GetBasicUserWithFriends(user.Id);
            var friendship = authUser.Friends.SingleOrDefault(x => x.User1Id == user.Id || x.User2Id == user.Id);

            if (friendship != null)
            {
                friendship.IsAccepted = true;

                await FriendshipGenericFacade.UpdateAsync(friendship);
            }

            return RedirectToAction("Index");
        }
    }
}