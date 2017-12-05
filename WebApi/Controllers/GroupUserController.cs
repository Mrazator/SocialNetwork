using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.Facades;

namespace WebApi.Controllers
{
    public class GroupUserController : ApiController
    {
        public GroupUserGenericFacade GroupUserGenericFacade { get; set; }
        public GroupGenericFacade GroupGenericFacade { get; set; }
        public UserGenericFacade UserGenericFacade { get; set; }

        [Route("api/GroupUser/GetUserGroups")]
        public async Task<IEnumerable<GroupDto>> GetUserGroups(int userId)
        {
            var user = await UserGenericFacade.GetAsync(userId);
            if (user == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var groups = await GroupUserGenericFacade.GetGroupsByUserIdAsync(userId);
            return groups;
        }

        [Route("api/GroupUser/GetGroupUsers")]
        public async Task<IEnumerable<UserDto>> GetGroupUsers(int groupId)
        {
            var group = await GroupGenericFacade.GetAsync(groupId);
            if (group == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var users = await GroupUserGenericFacade.GetUsersByGroupIdAsync(groupId);
            return users;
        }

        // GET: api/GroupUsers/2
        public async Task<GetGroupUsersDto> Get(int id)
        {
            var groupUser = await GroupUserGenericFacade.GetAsync(id);

            if (groupUser == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return groupUser;
        }

        // POST: api/GroupUsers
        public async Task<string> Post(GetGroupUsersDto entity)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var groupUserid = await GroupUserGenericFacade.CreateAsync(entity);

            if (groupUserid.Equals(0))
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return $"Created GroupUser with id: {groupUserid}";
        }

        // PUT: api/GroupUsers/5
        public async Task<string> Put(int id, GetGroupUsersDto entity)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            await GroupUserGenericFacade.UpdateAsync(entity);
            return $"Updated GroupUser with id: {id}";
        }

        // DELETE: api/GroupUsers/5
        public async Task<string> Delete(int id)
        {
            var success = await GroupUserGenericFacade.DeleteAsync(id);
            if (!success)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return $"Deleted GroupUser with id: {id}";
        }
    }
}