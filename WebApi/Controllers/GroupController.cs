using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.Facades;

namespace WebApi.Controllers
{
    public class GroupController : ApiController
    {
        public GroupFacade GroupFacade { get; set; }

        public async Task<IEnumerable<GroupDto>> GetBySubname(string subname)
        {
            if (string.IsNullOrWhiteSpace(subname))
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var groups = await GroupFacade.GetGroupsContainingSubNameAsync(subname);

            return groups;
        }

        // GET: api/Groups/2
        public async Task<GroupDto> Get(int id)
        {
            var group = await GroupFacade.GetAsync(id);

            if (group == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return group;
        }

        // POST: api/Groups
        public async Task<string> Post(GroupDto entity)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var groupId = await GroupFacade.CreateAsync(entity);

            if (groupId.Equals(0))
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return $"Created Group with id: {groupId}";
        }

        // PUT: api/Groups/5
        public async Task<string> Put(int id, GroupDto entity)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            await GroupFacade.UpdateAsync(entity);
            return $"Updated Group with id: {id}";
        }

        // DELETE: api/Groups/5
        public async Task<string> Delete(int id)
        {
            var success = await GroupFacade.DeleteAsync(id);
            if (!success)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return $"Deleted Group with id: {id}";
        }
    }
}