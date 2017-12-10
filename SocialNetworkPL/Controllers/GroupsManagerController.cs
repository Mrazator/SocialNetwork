
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Facades;
using SocialNetworkPL.Models;

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
            var authUser = await BasicUserFacade.GetUserByNickNameAsync(User.Identity.Name);

            var addUserToGroupDto = new AddUserToGroupDto
            {
                UserId = authUser.Id,
                GroupId = groupId,
                IsAccepted = true
            };

            await GroupGenericFacade.AddUserAsync(addUserToGroupDto);
            return RedirectToAction("Index");
        }

        public ActionResult CreateGroup()
        {

            return View("CreateGroup", null);
        }

        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> CreateGroup(GroupCreateDto group)
        {
            var authUser = await BasicUserFacade.GetUserByNickNameAsync(User.Identity.Name);
            var group_Id = await GroupGenericFacade.CreateGroup(group, authUser.Id);
            return RedirectToAction("Index", "GroupsManager", new { groupId = group_Id });
        }

        public async Task<ActionResult> AcceptInvitation(int groupId, int userId)
        {
            await GroupGenericFacade.AcceptInvitation(userId, groupId);
            return RedirectToAction("Index");
        }
    }
}