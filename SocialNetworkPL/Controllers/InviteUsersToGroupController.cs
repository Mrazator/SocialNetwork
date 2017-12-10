using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Facades;
using SocialNetworkPL.Models;

namespace SocialNetworkPL.Controllers
{
    public class InviteUsersToGroupController : Controller
    {
        public BasicUserFacade BasicUserFacade { get; set; }
        public UserGenericFacade UserGenericFacade { get; set; }
        public GroupGenericFacade GroupGenericFacade { get; set; }

        // GET: InviteUsersToGroup
        public async Task<ActionResult> Index([FromUri] string subname = "", int? groupId = null)
        {
            var filter = new UserFilterDto { SubName = subname };

            var user = await BasicUserFacade.GetUserByNickNameAsync(User.Identity.Name);
            var users = await BasicUserFacade.GetUsersBySubnameAsync(subname);

            var basicUserDtos = users as IList<BasicUserDto> ?? users.ToList();
            foreach (var u in basicUserDtos)
            {
                await BasicUserFacade.AssignGroupsToUserAsync(u);
            }

            var basicUserWithFriends = await BasicUserFacade.GetBasicUserWithGroups(user.Id);

            return View("InviteUsersToGroupView", new InviteUsersToGroupModel
            {
                Filter = filter,
                Users = basicUserDtos,
                User = basicUserWithFriends,
                GroupId = groupId
            });
        }

        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> Invite(int userId, int? groupid)
        {            
            var addUserToGroupDto = new AddUserToGroupDto
            {
                UserId = userId,
                GroupId = (int) groupid,
                IsAccepted = false
            };

            await GroupGenericFacade.AddUserAsync(addUserToGroupDto);
            return RedirectToAction("Index", new { groupId = groupid });
        }
    }
}