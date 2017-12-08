using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.Facades;
using SocialNetworkBL.DataTransferObjects.GroupProfileDtos;

namespace WebApi.Controllers
{
    public class GroupController : ApiController
    {
        public GroupGenericFacade GroupGenericFacade { get; set; }
        public GroupProfileFacade GroupProfileFacade { get; set; }

        [Route("api/Group/GetBySubname")]
        public async Task<IEnumerable<GroupDto>> GetBySubname(string subname)
        {
            if (string.IsNullOrWhiteSpace(subname))
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var groups = await GroupGenericFacade.GetGroupsContainingSubNameAsync(subname);

            return groups;
        }

        [Route("api/Group/CreatePost")]
        public async Task CreatePost(GroupProfilePostDto post)
        {
            await GroupProfileFacade.PostInGroup(post);
        }

        // GET: api/Groups/2
        public async Task<GroupDto> Get(int id)
        {
            var group = await GroupGenericFacade.GetAsync(id);

            if (group == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return group;
        }

        // POST: api/Groups
        public async Task<string> Post(GroupDto entity)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var groupId = await GroupGenericFacade.CreateAsync(entity);

            if (groupId.Equals(0))
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return $"Created Group with id: {groupId}";
        }

        // PUT: api/Groups/5
        public async Task<string> Put(int id, GroupDto entity)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            await GroupGenericFacade.UpdateAsync(entity);
            return $"Updated Group with id: {id}";
        }

        // DELETE: api/Groups/5
        public async Task<string> Delete(int id)
        {
            var success = await GroupGenericFacade.DeleteAsync(id);
            if (!success)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return $"Deleted Group with id: {id}";
        }
    }
}