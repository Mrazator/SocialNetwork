using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.Facades;

namespace WebApi.Controllers
{
    public class MessagesController : ApiController
    {
        public MessageFacade MessageFacade { get; set; }
        public FriendshipFacade FriendshipFacade { get; set; }

        [Route("api/Messages/GetChat")]
        public async Task<IEnumerable<MessageDto>> GetChat(int friendshipId)
        {
            var chat = await MessageFacade.GetMessagesByFriendshipIdAsync(friendshipId);
            return chat;
        }

        // GET: api/Messages/2
        public async Task<MessageDto> Get(int id)
        {
            var post = await MessageFacade.GetAsync(id);

            if (post == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return post;
        }

        // POST: api/Messages
        public async Task<string> Post(MessageDto entity)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var postId = await MessageFacade.CreateAsync(entity);

            if (postId.Equals(0))
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return $"Created Message with id: {postId}";
        }

        // PUT: api/Messages/5
        public async Task<string> Put(int id, MessageDto entity)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            await MessageFacade.UpdateAsync(entity);
            return $"Updated Message with id: {id}";
        }

        // DELETE: api/Messages/5
        public async Task<string> Delete(int id)
        {
            var success = await MessageFacade.DeleteAsync(id);
            if (!success)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return $"Deleted Message with id: {id}";
        }
    }
}