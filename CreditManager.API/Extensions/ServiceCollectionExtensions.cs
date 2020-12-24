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
           /* #region Repositories
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ITransactionDetailsRepository, TransactionDetailsRepository>();
            #endregion

            #region Services
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ITransactionDetailsService, TransactionDetailsService>();
            #endregion*/

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
