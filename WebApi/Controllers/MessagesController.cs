﻿using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.Facades;

namespace WebApi.Controllers
{
    public class MessagesController : ApiController
    {
        public MessageGenericFacade MessageGenericFacade { get; set; }
        public FriendshipGenericFacade FriendshipGenericFacade { get; set; }

        [Route("api/Messages/GetChat")]
        public async Task<IEnumerable<MessageDto>> GetChat(int friendshipId)
        {
            var chat = await MessageGenericFacade.GetMessagesByFriendshipIdAsync(friendshipId);
            return chat.Items;
        }

        // GET: api/Messages/2
        public async Task<MessageDto> Get(int id)
        {
            var post = await MessageGenericFacade.GetAsync(id);

            if (post == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return post;
        }

        // POST: api/Messages
        public async Task<string> Post(MessageDto entity)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var postId = await MessageGenericFacade.CreateAsync(entity);

            if (postId.Equals(0))
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return $"Created Message with id: {postId}";
        }

        // PUT: api/Messages/5
        public async Task<string> Put(int id, MessageDto entity)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            await MessageGenericFacade.UpdateAsync(entity);
            return $"Updated Message with id: {id}";
        }

        // DELETE: api/Messages/5
        public async Task<string> Delete(int id)
        {
            var success = await MessageGenericFacade.DeleteAsync(id);
            if (!success)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return $"Deleted Message with id: {id}";
        }
    }
}