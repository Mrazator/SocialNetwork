using System.Collections.Generic;
using System.Threading.Tasks;
using BL.Tests.FacadeTests.Common;
using Moq;
using NUnit.Framework;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Facades;
using SocialNetworkBL.QueryObjects;
using SocialNetworkBL.Services.Common;
using SocialNetworkBL.Services.User;
using SocialNetworkDAL.Entities;

namespace BL.Tests.FacadeTests
{
    [TestFixture]
    public class UserFacadeTests
    {
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

            var expectedQueryResult = new QueryResultDto<UserDto, UserFilterDto> {Items = expectedUsers};
            var mockManager = new FacadeMockManager();
            var uowMock = FacadeMockManager.ConfigureUowMock();
            var queryMock = mockManager.ConfigureQueryObjectMock<UserDto, User, UserFilterDto>(expectedQueryResult);
            var userService = new UserService(null, null, queryMock.Object);
            var crudService = new CrudQueryServiceBase<User, UserDto, UserFilterDto>(null, null, queryMock.Object);
            var userFacade = new UserGenericFacade(uowMock.Object, crudService, userService);

            var actualUsers = await userFacade.GetAllItemsAsync();

            Assert.AreEqual(expectedUsers, actualUsers.Items);
        }

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

            var expectedQueryResult = new QueryResultDto<UserDto, UserFilterDto> {Items = expectedUsers};

            var uowMock = FacadeMockManager.ConfigureUowMock();
            //nepouzivam genericky FacadeMockManager, vytvarim si vlastni queryMock -> vice kodu ale presnejsi -> viz dalsi komentar
            var queryMock = new Mock<UserQueryObject>(MockBehavior.Strict, null, null);
            queryMock
                .Setup(x => x.ExecuteQuery(new UserFilterDto
                {
                    SubName = "Misko"
                }))
                .ReturnsAsync(expectedQueryResult);
            var userService = new UserService(null, null, queryMock.Object);
            var crudService = new CrudQueryServiceBase<User, UserDto, UserFilterDto>(null, null, queryMock.Object);
            var userFacade = new UserGenericFacade(uowMock.Object, crudService, userService);
            //Pokud zde totiz zmenim Misko na napr "zlyMisko" tak uz to neprochazi -> U PostFacadeTestu vsak prochazi -> vice komentaru tam
            var actualUsers = await userFacade.GetUsersContainingSubNameAsync("Misko");

            Assert.AreEqual(expectedUsers, actualUsers);
        }
    }
}