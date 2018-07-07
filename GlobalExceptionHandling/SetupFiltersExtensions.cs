using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Owin;

namespace GlobalExceptionHandling
{
    public static class SetupFiltersExtensions
    {
        public static IAppBuilder SetupFilters(this IAppBuilder builder, HttpConfiguration config)
        {
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
            config.Services.Add(typeof(IExceptionLogger), new Logger.Logger("D://"));

            return builder;
        }
    }
}
