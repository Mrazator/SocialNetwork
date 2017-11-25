using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Windsor;
using SocialNetworkBL.Config;
using SocialNetworkPL.Windsor;

namespace SocialNetworkPL
{
    public class MvcApplication : HttpApplication
    {
        private static readonly IWindsorContainer container = new WindsorContainer();


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            BootstrapContainer();
        }

        private void BootstrapContainer()
        {
            container.Install(new PresentationLayerInstaller());
            container.Install(new BusinessLayerInstaller());

            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}