using CreditManager.API.Domain.Repositories;
using CreditManager.API.Domain.Services;
using CreditManager.API.Persistence.Repositories;
using CreditManager.API.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditManager.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterClassesAndInterfaces(this IServiceCollection services)
        {
            services.AddScoped<IEntityRepository, EntityRepository>();
            services.AddScoped<IEntityService, EntityService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
