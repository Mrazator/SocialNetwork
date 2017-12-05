using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.Facades;

namespace WebApi.Controllers
{
    public class CommentController : ApiController
    {
        public CommentGenericFacade CommentGenericFacade { get; set; }
        public PostGenericFacade PostGenericFacade { get; set; }


        public async Task<IEnumerable<CommentDto>> GetPostComments(int postId)
        {
            var post = await PostGenericFacade.GetAsync(postId);
            if (post == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var comments = await CommentGenericFacade.GetPostCommentsAsync(postId);
            return comments;
        }

        // GET: api/Comments/2
        public async Task<CommentDto> Get(int id)
        {
            var comment = await CommentGenericFacade.GetAsync(id);

            if (comment == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return comment;
        }

        // POST: api/Comments
        public async Task<string> Post(CommentDto entity)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var commentId = await CommentGenericFacade.CreateAsync(entity);

            if (commentId.Equals(0))
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return $"Created Comment with id: {commentId}";
        }

        // PUT: api/Comments/5
        public async Task<string> Put(int id, CommentDto entity)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            await CommentGenericFacade.UpdateAsync(entity);
            return $"Updated Comment with id: {id}";
        }

        // DELETE: api/Comments/5
        public async Task<string> Delete(int id)
        {
            var success = await CommentGenericFacade.DeleteAsync(id);
            if (!success)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return $"Deleted Comment with id: {id}";
        }
    }
}