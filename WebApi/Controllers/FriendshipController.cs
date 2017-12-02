using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.Facades;

namespace WebApi.Controllers
{
    public class FriendshipController : ApiController
    {
        public FriendshipFacade FriendshipFacade { get; set; }
        public UserFacade UserFacade { get; set; }

        public async Task<IEnumerable<int>> GetUserFriendIds(int userId)
        {
            var userDto = await UserFacade.GetAsync(userId);

            if (userDto == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var friendsIds = await FriendshipFacade.GetFriendsIdsByUserIdAsync(userId);

            return friendsIds;
        }

        // GET: api/Friendships/2
        public async Task<FriendshipDto> Get(int id)
        {
            var post = await FriendshipFacade.GetAsync(id);

            if (post == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return post;
        }

        // POST: api/Friendships
        public async Task<string> Post(FriendshipDto entity)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var postId = await FriendshipFacade.CreateAsync(entity);

            if (postId.Equals(0))
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return $"Created Friendship with id: {postId}";
        }

        // PUT: api/Friendships/5
        public async Task<string> Put(int id, FriendshipDto entity)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            await FriendshipFacade.UpdateAsync(entity);
            return $"Updated Friendship with id: {id}";
        }

        // DELETE: api/Friendships/5
        public async Task<string> Delete(int id)
        {
            var success = await FriendshipFacade.DeleteAsync(id);
            if (!success)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return $"Deleted Friendship with id: {id}";
        }
    }
}