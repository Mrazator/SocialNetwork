using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Routing;
using Castle.Windsor;
using SocialNetworkBL.Config;

namespace WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private readonly IWindsorContainer container = new WindsorContainer();


        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            BootstrapContainer();
        }
        private void BootstrapContainer()
        {
            container.Install(new WebApiInstaller());
            container.Install(new BusinessLayerInstaller());

            GlobalConfiguration.Configuration.Services
                .Replace(typeof(IHttpControllerActivator), new WindsorCompositionRoot(container));
        }

        public override void Dispose()
        {
            container.Dispose();
            base.Dispose();
        }
    }
}
