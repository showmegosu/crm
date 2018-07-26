using System.Configuration;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Logger;
using Tourism.DAL;
using Unity;
using Unity.Injection;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();

            // Register Logger type
            container.RegisterType<ILogger, Logger.Logger>(
                new InjectionConstructor(ConfigurationManager.ConnectionStrings["LogFolder"].ConnectionString));

            // Register Repository type
            container.RegisterType<IClientRepository, ClientRepository>(new InjectionConstructor(
                ConfigurationManager.ConnectionStrings["CrmRepository"].ConnectionString,
                container.Resolve<ILogger>()));
            container.RegisterType<IManagerRepository, ManagerRepository>(new InjectionConstructor(
                ConfigurationManager.ConnectionStrings["CrmRepository"].ConnectionString,
                container.Resolve<ILogger>()));

            config.DependencyResolver = new UnityResolver(container);

            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
            config.Services.Add(typeof(IExceptionLogger),
                new Logger.Logger(ConfigurationManager.ConnectionStrings["LogFolder"].ConnectionString));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v1/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
            );
        }
    }
}