﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using Infrastructure;
using Infrastructure.Query;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.QueryObjects.Common;
using SocialNetworkBL.Services.Common;

namespace SocialNetworkBL.Services.User
{
    public class UserService : CrudQueryServiceBase<SocialNetworkDAL.Entities.User, UserDto, UserFilterDto>, IUserService
    {
        private const int PBKDF2IterCount = 100000;
        private const int PBKDF2SubkeyLength = 160 / 8;
        private const int saltSize = 128 / 8;

        public UserService(IMapper mapper, IRepository<SocialNetworkDAL.Entities.User> repository,
            QueryObjectBase<UserDto, SocialNetworkDAL.Entities.User, UserFilterDto, IQuery<SocialNetworkDAL.Entities.User>> query)
            : base(mapper, repository, query)
        {
        }

        public async Task<IEnumerable<UserDto>> GetUsersContainingSubNameAsync(string subName)
        {
            var queryResult = await Query.ExecuteQuery(new UserFilterDto {SubName = subName});
            return queryResult?.Items;
        }

        public async Task<UserDto> GetByNickNameAsync(string nickName)
        {
            var queryResult = await Query.ExecuteQuery(new UserFilterDto {NickName = nickName});
            return queryResult?.Items.FirstOrDefault();
        }

        public async Task<int> RegisterUserAsync(UserCreateDto userDto)
        {
            var user = Mapper.Map<SocialNetworkDAL.Entities.User>(userDto);

            if (await GetIfUserExistsAsync(user.NickName))
                throw new ArgumentException();

            var password = CreateHash(userDto.Password);
            user.PasswordHash = password.Item1;
            user.PasswordSalt = password.Item2;

            Repository.Create(user);

            return user.Id;
        }

        public async Task<bool> AuthorizeUserAsync(string nickName, string password)
        {
            var userResult = await Query.ExecuteQuery(new UserFilterDto {NickName = nickName});
            var user = userResult.Items.SingleOrDefault();

            if (user != null)
                return VerifyHashedPassword(user.PasswordHash, user.PasswordSalt, password);
            return false;
        }

        private async Task<bool> GetIfUserExistsAsync(string nickName)
        {
            var queryResult = await Query.ExecuteQuery(new UserFilterDto {NickName = nickName});
            return queryResult.Items.Count() == 1;
        }

        private bool VerifyHashedPassword(string hashedPassword, string salt, string password)
        {
            var hashedPasswordBytes = Convert.FromBase64String(hashedPassword);
            var saltBytes = Convert.FromBase64String(salt);

            using (var deriveBytes = new Rfc2898DeriveBytes(password, saltBytes, PBKDF2IterCount))
            {
                var generatedSubkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);
                return hashedPasswordBytes.SequenceEqual(generatedSubkey);
            }
        }

        private Tuple<string, string> CreateHash(string password)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, saltSize, PBKDF2IterCount))
            {
                var salt = deriveBytes.Salt;
                var subkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);

                return Tuple.Create(Convert.ToBase64String(subkey), Convert.ToBase64String(salt));
            }
        }
    }
}