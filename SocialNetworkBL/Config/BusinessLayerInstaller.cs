using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SocialNetwork.Config;
using SocialNetworkBL.Facades.Common;
using SocialNetworkBL.QueryObjects.Common;
using SocialNetworkBL.Services.Common;

namespace SocialNetworkBL.Config
{
    public class BusinessLayerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            new EntityFrameworkInstaller().Install(container, store);

            container.Register(
                Component.For(typeof(QueryObjectBase<,,,>))
                    .ImplementedBy(typeof(IQueryObjectBase))
                    .LifestyleTransient(),
                Classes.FromThisAssembly()
                    .BasedOn(typeof(QueryObjectBase<,,,>))
                    .WithServiceBase()
                    .LifestyleTransient(),
                Classes.FromThisAssembly()
                    .BasedOn<ServiceBase>()
                    .WithServiceDefaultInterfaces()
                    .LifestyleTransient(),
                Classes.FromThisAssembly()
                    .BasedOn(typeof(FacadeBase<,,>))
                    .LifestyleTransient(),
                Component.For<IMapper>()
                    .Instance(new Mapper(new MapperConfiguration(MappingConfig.ConfigureMapping)))
                    .LifestyleSingleton()
            );

            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));
        }
    }
}