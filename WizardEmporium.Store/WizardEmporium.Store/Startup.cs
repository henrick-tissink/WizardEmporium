using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WizardEmporium.Common.SharedSwaggerConfig;
using WizardEmporium.Store.Repository;
using WizardEmporium.Store.Service;

namespace WizardEmporium.Store
{
    public class Startup
    {
        protected Startup() { }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Swagger generation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Wizard Emporium Store API", Version = "v1" });
                c.OperationFilter<DescribeErrorTypeOnResponseOperationFilter>();
            });

            // Database config
            services.AddSingleton<IStoreRepo>(new StoreRepo(Configuration.GetConnectionString("StoreDB")));

            // Services
            services.AddSingleton<IStoreService, StoreService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // Swagger generation
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("swagger/v1/swagger.json", "Wizard Emporium Store API");
                options.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
