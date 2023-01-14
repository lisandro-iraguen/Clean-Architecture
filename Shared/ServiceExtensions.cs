
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Application.Interfaces;
using Shared.Services;

namespace Shared
{
    public static class ServiceExtensions
    {
        public static void AddSharednfrastructureLayer(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddTransient<IDateTimeService, DateTimeService>();
        }
    }
}
