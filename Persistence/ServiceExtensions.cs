using Application.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repository;
using System.Reflection;

namespace Persistence
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceInfrastructureLayer(this IServiceCollection service,IConfiguration configuration)
        {
            service.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),b=>b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
            ));
           
            service.AddTransient(typeof(IRepositoryAsync<>),typeof(MyRepositoryAsync<>));
        }
    }
}
