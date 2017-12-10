using System.Threading.Tasks;
using System.Web.Mvc;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Facades;
using SocialNetworkPL.Models;

namespace SocialNetworkPL.Controllers
{
    public class ChatController : Controller
    {
        public FriendsWithChatFacade FriendsWithChatFacade { get; set; }
        public BasicUserFacade BasicUserFacade { get; set; }

        public async Task<ActionResult> Index(int userId = 0)
        {
            var authUser = await BasicUserFacade.GetUserByNickNameAsync(User.Identity.Name);
            var filter = new FriendshipFilterDto() {UserId = authUser.Id};

            var friendsWithChat = await FriendsWithChatFacade.GetFriendsWithChatAsync(filter);

            return View("Chat", new ChatModel
            {
                AuthenticatedUser = authUser,
                FriendWithChat = friendsWithChat.Items,
                Filter = filter
            });
        }
    }
}