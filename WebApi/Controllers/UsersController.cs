using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.Facades;

namespace WebApi.Controllers
{
    public class UsersController : ApiController
    {
        public UserFacade UserFacade { get; set; }

        // GET: api/Users/Get?subname=Marcel
        [Route("api/Users/GetBySubname")]
        public async Task<IEnumerable<UserDto>> GetBySubname(string subname)
        {
            if (string.IsNullOrWhiteSpace(subname))
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var users = await UserFacade.GetUsersContainingSubNameAsync(subname);

            if (users == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var userDtos = users as IList<UserDto> ?? users.ToList();

            foreach (var user in userDtos)
            {
                user.Id = 0;
            }

            return userDtos;
        }

        // GET: api/Users/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Users
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}
