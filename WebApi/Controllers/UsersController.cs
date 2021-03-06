﻿using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.Facades;

namespace WebApi.Controllers
{
    public class UsersController : ApiController
    {
        public UserGenericFacade UserGenericFacade { get; set; }

        // GET: api/Users/GetBySubname?subname=Marcel
        [Route("api/Users/GetBySubname")]
        public async Task<IEnumerable<UserDto>> GetBySubname(string subname)
        {
            if (string.IsNullOrWhiteSpace(subname))
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var users = await UserGenericFacade.GetUsersContainingSubNameAsync(subname);

            if (users == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //var userDtos = users as IList<UserDto> ?? users.ToList();

            //foreach (var user in userDtos)
            //{
            //    user.Id = 0;
            //}

            return users;
        }

        // GET: api/Users
        [Route("api/Userss")]
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var users = await UserGenericFacade.GetAllItemsAsync();
            return users.Items;
        }

        // GET: api/Users/2
        public async Task<UserDto> Get(int id)
        {
            var user = await UserGenericFacade.GetAsync(id);

            if (user == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return user;
        }

        // POST: api/Users
        public async Task<string> Post(UserDto entity)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var userId = await UserGenericFacade.CreateAsync(entity);

            if (userId.Equals(0))
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            return $"Created user with id: {userId}";
        }

        // PUT: api/Users/5
        public async Task<string> Put(int id, UserDto entity)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            await UserGenericFacade.UpdateAsync(entity);
            return $"Updated user with id: {id}";
        }

        // DELETE: api/Users/5
        public async Task<string> Delete(int id)
        {
            var success = await UserGenericFacade.DeleteAsync(id);
            if (!success)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return $"Deleted user with id: {id}";
        }
    }
}