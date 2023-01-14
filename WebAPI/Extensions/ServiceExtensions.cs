
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddAPIVersioningExtension(this IServiceCollection service)
        {
            service.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
        }
    }
}
