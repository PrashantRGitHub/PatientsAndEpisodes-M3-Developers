using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using RestApi.DependencyInjection;

namespace RestApi
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var diContainer = new ApplicationDependencyContainer(Assembly.GetExecutingAssembly());
            diContainer.Build();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            config.DependencyResolver = diContainer.WebApiDependencyResolver;

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(config);
        }
    }
}