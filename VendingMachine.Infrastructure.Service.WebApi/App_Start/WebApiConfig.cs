using System.Web.Http;
using VendingMachine.Domain.Interfaces;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using VendingMachine.Infrastructure.Data;
using System.Web.Configuration;

namespace VendingMachine.Infrastructure.Service.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new Container();
#pragma warning disable CS0618 // Type or member is obsolete
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
#pragma warning restore CS0618 // Type or member is obsolete
            container.Register<IProductRepository>(() => new ProductRepository(), Lifestyle.Scoped);
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
