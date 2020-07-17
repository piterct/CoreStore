using CoreStore.Domain.StoredContext.Handlers;
using CoreStore.Domain.StoredContext.Repositories;
using CoreStore.Domain.StoredContext.Services;
using CoreStore.Infra.StoredContext.DataContexts;
using CoreStore.Infra.StoredContext.Repositories;
using CoreStore.Infra.StoredContext.Services;
using CoreStore.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreStore.Api.Helpers.DependencyInjectionConfig
{
    public static class DependencyRegister
    {
        public static void AddScoped(this IServiceCollection services, IConfiguration configuration)
        {

            #region IOptions
            services.Configure<Settings>(configuration.GetSection("connectionString"));
            #endregion

            #region Configurations
            services.AddScoped<CoreDataContext, CoreDataContext>();

            #endregion

            #region Handlers
            services.AddTransient<CustomerHandler, CustomerHandler>();

            #endregion

            #region Repositories
            services.AddTransient<ICustomerRepository, CustomerRepository>();

            #endregion

            #region External Services
            services.AddTransient<IEmailService, EmailService>();

            #endregion
        }
    }
}
