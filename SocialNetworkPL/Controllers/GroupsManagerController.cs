using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Facades;
using SocialNetworkPL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SocialNetworkPL.Controllers
{
    public class GroupsManagerController : Controller
    {
        public GroupGenericFacade GroupGenericFacade { get; set; }
        //public GroupUserGenericFacade GroupUserGenericFacade { get; set; }
        public BasicUserFacade BasicUserFacade { get; set; }

        // GET: GroupManager
        public async Task<ActionResult> Index([FromUri] string subname)
        {
            var filter = new GroupFilterDto { SubName = subname };

            var user = await BasicUserFacade.GetUserByNickNameAsync(User.Identity.Name);
            var groups = await GroupGenericFacade.GetGroupsContainingSubNameAsync(subname);
            var basicUserWithGroups = await BasicUserFacade.GetBasicUserWithGroups(user.Id);

            return View("GroupManagementView", new FindGroupsModel
            {
                Filter = filter,
                Groups = groups,
                User = basicUserWithGroups
            });
        }

        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> BecomeMember(int groupId)
        {
            var user = await BasicUserFacade.GetUserByNickNameAsync(User.Identity.Name);

            var addUserToGroupDto = new AddUserToGroupDto
            {
                UserId = user.Id,
                GroupId = groupId,
                IsAccepted = true
            };

            await GroupGenericFacade.AddUserAsync(addUserToGroupDto);
            return RedirectToAction("Index");
        }
    }
}