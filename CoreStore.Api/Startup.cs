using CoreStore.Domain.StoredContext.Repositories;
using CoreStore.Domain.StoredContext.Services;
using CoreStore.Infra.StoredContext.DataContexts;
using CoreStore.Infra.StoredContext.Repositories;
using CoreStore.Infra.StoredContext.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CoreStore.Api
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddScoped<CoreDataContext, CoreDataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
        }
    }
}
