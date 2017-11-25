using SocialNetworkBL.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.Facades;
using BL.Tests.FacadeTests.Common;
using Infrastructure.Query;
using Moq;
using SocialNetwork.Entities;
using SocialNetworkBL.Services.Users;
using SocialNetworkBL.Services.Common;
using NUnit.Framework;
using SocialNetworkBL.QueryObjects;
using SocialNetworkBL.QueryObjects.Common;

namespace BL.Tests.FacadeTests
{
    [TestFixture]
    public class UserFacadeTests
    {
        [Test]
        public async Task GetUsersContainingGivenSubnameAsyncTest()
        {
            var expectedUsers = new List<UserDto>
            {
                new UserDto
                {
                    Id = 1,
                    NickName = "Misko"
                },
                new UserDto
                {
                    Id = 2,
                    NickName = "Misko2"
                }
            };

            var expectedQueryResult = new QueryResultDto<UserDto, UserFilterDto> { Items = expectedUsers };

            var uowMock = FacadeMockManager.ConfigureUowMock();
            //nepouzivam genericky FacadeMockManager, vytvarim si vlastni queryMock -> vice kodu ale presnejsi -> viz dalsi komentar
            var queryMock = new Mock<UserQueryObject>(MockBehavior.Strict, null, null);
            queryMock
                .Setup(x => x.ExecuteQuery(new UserFilterDto()
                {
                    SubName = "Misko"
                }))
                .ReturnsAsync(expectedQueryResult);
            var userService = new UserService(null, null, queryMock.Object);
            var crudService = new CrudQueryServiceBase<SocialNetwork.Entities.User, UserDto, UserFilterDto>(null, null, queryMock.Object);
            var userFacade = new UserFacade(uowMock.Object, crudService, userService);
            //Pokud zde totiz zmenim Misko na napr "zlyMisko" tak uz to neprochazi -> U PostFacadeTestu vsak prochazi -> vice komentaru tam
            var actualUsers = await userFacade.GetUsersContainingSubNameAsync("Misko");

            Assert.AreEqual(expectedUsers, actualUsers);
        }

        [Test]
        public async Task GetAllUsersAsync_ThreeExistingCustomer_ReturnCorrectList()
        {
            var expectedUsers = new List<UserDto>
            {
                new UserDto
                {
                    Id = 1,
                    NickName = "Misko"
                },
                new UserDto
                {
                    Id = 2,
                    NickName = "Misko2"
                },
                new UserDto
                {
                    Id = 3,
                    NickName = "Marcello"
                }
            };

            var expectedQueryResult = new QueryResultDto<UserDto, UserFilterDto> { Items = expectedUsers };
            var mockManager = new FacadeMockManager();
            var uowMock = FacadeMockManager.ConfigureUowMock();
            var queryMock = mockManager.ConfigureQueryObjectMock<UserDto, SocialNetwork.Entities.User, UserFilterDto>(expectedQueryResult);
            var userService = new UserService(null, null, queryMock.Object);
            var crudService = new CrudQueryServiceBase<SocialNetwork.Entities.User, UserDto, UserFilterDto>(null, null, queryMock.Object);
            var userFacade = new UserFacade(uowMock.Object, crudService, userService);

            var actualUsers = await userFacade.GetAllItemsAsync();

            Assert.AreEqual(expectedUsers, actualUsers.Items);
        }
    }
}
