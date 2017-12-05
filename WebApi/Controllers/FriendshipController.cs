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
        public FriendshipGenericFacade FriendshipGenericFacade { get; set; }
        public UserGenericFacade UserGenericFacade { get; set; }

        public async Task<IEnumerable<BasicUserDto>> GetUserFriends(int userId)
        {
            var userDto = await UserGenericFacade.GetAsync(userId);

            if (userDto == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var friends = await FriendshipGenericFacade.GetFriendsIdsByUserIdAsync(userId);

            return friends;
        }

        // GET: api/Friendships/2
        public async Task<FriendshipDto> Get(int id)
        {
            var post = await FriendshipGenericFacade.GetAsync(id);

            if (post == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return post;
        }

        // POST: api/Friendships
        public async Task<string> Post(FriendshipDto entity)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var postId = await FriendshipGenericFacade.CreateAsync(entity);

            if (postId.Equals(0))
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return $"Created Friendship with id: {postId}";
        }

        // PUT: api/Friendships/5
        public async Task<string> Put(int id, FriendshipDto entity)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            await FriendshipGenericFacade.UpdateAsync(entity);
            return $"Updated Friendship with id: {id}";
        }

        // DELETE: api/Friendships/5
        public async Task<string> Delete(int id)
        {
            var success = await FriendshipGenericFacade.DeleteAsync(id);
            if (!success)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return $"Deleted Friendship with id: {id}";
        }
    }
}