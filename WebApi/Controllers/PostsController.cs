using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Enums;
using SocialNetworkBL.Facades;

namespace WebApi.Controllers
{
    public class PostsController : ApiController
    {
        public PostGenericFacade PostGenericFacade { get; set; }
        public UserGenericFacade UserGenericFacade { get; set; }
        public GroupGenericFacade GroupGenericFacade { get; set; }

        // GET: api/Posts/GetByUserId?userId=666
        public async Task<IEnumerable<PostDto>> GetByUserId(int userId)
        {
            var userDto = await UserGenericFacade.GetAsync(userId);

            if (userDto == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //if (userDto.PostVisibilityPreference != Visibility.Visible)
            //    throw new HttpResponseException(HttpStatusCode.NotFound);

            var posts = await PostGenericFacade.GetPostsByUserIdAsync(userId);
            return posts;
        }

        // GET: api/Posts/GetByGroupId?groupId=666
        public async Task<IEnumerable<PostDto>> GetByGroupId(int groupId)
        {
            var groupDto = await GroupGenericFacade.GetAsync(groupId);

            if (groupDto == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var posts = await PostGenericFacade.GetPostsByGroupIdAsync(groupId);
            return posts;
        }

        // GET: api/Posts/2
        public async Task<PostDto> Get(int id)
        {
            var post = await PostGenericFacade.GetAsync(id);

            if (post == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return post;
        }

        // POST: api/Posts
        public async Task<string> Post(PostDto entity)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var postId = await PostGenericFacade.CreateAsync(entity);

            if (postId.Equals(0))
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return $"Created Post with id: {postId}";
        }

        // PUT: api/Posts/5
        public async Task<string> Put(int id, PostDto entity)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            await PostGenericFacade.UpdateAsync(entity);
            return $"Updated post with id: {id}";
        }

        // DELETE: api/Posts/5
        public async Task<string> Delete(int id)
        {
            var success = await PostGenericFacade.DeleteAsync(id);
            if (!success)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return $"Deleted post with id: {id}";
        }
    }
}