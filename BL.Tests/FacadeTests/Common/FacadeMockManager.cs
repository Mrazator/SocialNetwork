using AutoMapper;
using Infrastructure;
using Infrastructure.Query;
using Infrastructure.UnitOfWork;
using Moq;
using SocialNetworkBL.Config;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.QueryObjects.Common;

namespace BL.Tests.FacadeTests.Common
{
    //Genericky FacadeMockManager z DemoEshopu - vyzkouseny na teste PostFacadeTests (vic komentare tam)
    public class FacadeMockManager
    {
        internal int CapturedCreatedId { get; private set; }

        internal int CapturedUpdatedStoredUnits { get; private set; }

        internal static IMapper ConfigureRealMapper()
        {
            return new Mapper(new MapperConfiguration(MappingConfig.ConfigureMapping));
        }

        internal static Mock<IUnitOfWorkProvider> ConfigureUowMock()
        {
            var uowMock = new Mock<IUnitOfWorkProvider>(MockBehavior.Loose);
            uowMock.Setup(uow => uow.Create()).Returns(new StubUow());
            return uowMock;
        }

        internal Mock<IRepository<TEntity>> ConfigureRepositoryMock<TEntity>() where TEntity : class, IEntity, new()
        {
            return new Mock<IRepository<TEntity>>(MockBehavior.Loose);
        }

        internal Mock<IRepository<TEntity>> ConfigureGetRepositoryMock<TEntity>(TEntity result)
            where TEntity : class, IEntity, new()
        {
            var mockRepository = new Mock<IRepository<TEntity>>(MockBehavior.Loose);
            mockRepository.Setup(repository => repository.GetAsync(It.IsAny<int>(), It.IsAny<string[]>()))
                .ReturnsAsync(result);
            mockRepository.Setup(repository => repository.GetAsync(It.IsAny<int>())).ReturnsAsync(result);
            return mockRepository;
        }

        internal Mock<IRepository<TEntity>> ConfigureCreateRepositoryMock<TEntity>(string propertyName)
            where TEntity : class, IEntity, new()
        {
            var mockRepository = new Mock<IRepository<TEntity>>(MockBehavior.Loose);
            mockRepository.Setup(repo => repo.Create(It.IsAny<TEntity>()))
                .Callback<TEntity>(param =>
                    CapturedCreatedId = (int) (param.GetType().GetProperty(propertyName)?.GetValue(param) ?? 0));
            return mockRepository;
        }

        internal Mock<IRepository<TEntity>> ConfigureGetAndUpdateRepositoryMock<TEntity>(TEntity result,
            string propertyName) where TEntity : class, IEntity, new()
        {
            var mockRepository = ConfigureGetRepositoryMock(result);
            mockRepository.Setup(repo => repo.Update(It.IsAny<TEntity>()))
                .Callback<TEntity>(param =>
                    CapturedUpdatedStoredUnits =
                        (int) (param.GetType().GetProperty(propertyName)?.GetValue(param) ?? 0));
            return mockRepository;
        }

        internal Mock<QueryObjectBase<TDto, TEntity, TFilterDto, IQuery<TEntity>>>
            ConfigureQueryObjectMock<TDto, TEntity, TFilterDto>(QueryResultDto<TDto, TFilterDto> result)
            where TEntity : class, IEntity, new()
            where TFilterDto : FilterDtoBase
        {
            var queryMock =
                new Mock<QueryObjectBase<TDto, TEntity, TFilterDto, IQuery<TEntity>>>(MockBehavior.Loose, null, null);
            queryMock
                .Setup(query => query.ExecuteQuery(It.IsAny<TFilterDto>()))
                .ReturnsAsync(result);
            return queryMock;
        }
    }
}