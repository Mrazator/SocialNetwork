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
using SocialNetworkBL.Services.Friendships;
using SocialNetworkPL.Models;

namespace SocialNetworkPL.Controllers
{
    public class UsersManagerController : Controller
    {
        //pouze dve fasady, prijde mi zbytecnedelat pro tohle specialni fasadu,
        //kdyz mam takhle hezke genericke fasady, ktere muzu vyuzit
        //kdybych to vsak delal znova, tak uz radsi pro konzistenci specialni fasadu vytvorim
        public FriendshipGenericFacade FriendshipGenericFacade { get; set; }
        public BasicUserFacade BasicUserFacade { get; set; }
        public UserGenericFacade UserGenericFacade { get; set; }

        //Vypise se pouze prvnich 100 hledani
        private const int UsersCount = 100;

        public async Task<ActionResult> Index([FromUri] string subname)
        {
            var filter = new UserFilterDto { SubName = subname };

            var user = await BasicUserFacade.GetUserByNickNameAsync(User.Identity.Name);
            //var users2 = await UserGenericFacade.GetUsersContainingSubNameAsync(subname);
            var users = await BasicUserFacade.GetUsersBySubnameAsync(filter);
            var basicUserWithFriends = await BasicUserFacade.GetBasicUserWithFriends(user.Id);

            return View("FriendManagementView", new FindUsersModel
            {
                Filter = filter,
                Users = users,
                User = basicUserWithFriends
            });
        }

        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> AddFriend(int id)
        {
            var user = await BasicUserFacade.GetUserByNickNameAsync(User.Identity.Name);

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
            var user = await BasicUserFacade.GetUserByNickNameAsync(User.Identity.Name);
            var authUser = await BasicUserFacade.GetBasicUserWithFriends(user.Id);
            var friendship = authUser.Friends.SingleOrDefault(x => x.User1Id == friendId || x.User2Id == friendId);

            if (friendship != null)
            {
                friendship.IsAccepted = true;

                await FriendshipGenericFacade.UpdateAsync(friendship);
            }

            return RedirectToAction("Index");
        }
    }
}