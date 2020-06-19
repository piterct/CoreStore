using CoreStore.Domain.StoredContext.Handlers;
using CoreStore.Domain.StoredContext.Repositories;
using CoreStore.Domain.StoredContext.Services;
using CoreStore.Infra.StoredContext.DataContexts;
using CoreStore.Infra.StoredContext.Repositories;
using CoreStore.Infra.StoredContext.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Elmah.Io.AspNetCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using CoreStore.Shared;
using CoreStore.Api.Helpers.DependencyInjectionConfig;

namespace CoreStore.Api
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();

            services.AddResponseCompression();
         
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Core Store",
                    Description = "API em .net core",
                    Contact = new OpenApiContact() { Name = "CoreStore", Email = "michael.peter@developer.com.br" }
                });
            });

            services.AddElmahIo(o =>
            {
                o.ApiKey = "f3b501c8dc22437cb0c710aca44d9a60";
                o.LogId = new Guid("5233fefc-0472-46b0-a028-c8717d5926c4");
            });

            Settings.ConnectionString = $"{Configuration["connectionString"]}";

            ConfigureDI(services, Configuration);

        }

        public static void ConfigureDI(IServiceCollection services, IConfiguration configuration)
        {
            //sign the services to di container   
            DependencyRegister.AddScoped(services, configuration);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
            app.UseResponseCompression();

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Core Store - V1");
            });

            app.UseElmahIo();
        }
    }
}
