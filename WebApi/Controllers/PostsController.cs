using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Facades;

namespace WebApi.Controllers
{
    public class PostsController : ApiController
    {
        public PostFacade PostFacade { get; set; }

        // GET: api/Posts
        public async Task<QueryResultDto<PostDto, PostFilterDto>> Get()
        {
            var posts = await PostFacade.GetPostsAsync(null);
            return posts;
        }

        // GET: api/Posts/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Posts
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Posts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Posts/5
        public void Delete(int id)
        {
        }
    }
}
