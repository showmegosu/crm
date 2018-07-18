using System.Configuration;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Logger;
using Tourism.DAL;
using Unity;
using Unity.Lifetime;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IRepository, ClientRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ILogger, Logger.Logger>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
            config.Services.Add(typeof(IExceptionLogger),
                new Logger.Logger(ConfigurationManager.ConnectionStrings["LogFolder"].ConnectionString));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
