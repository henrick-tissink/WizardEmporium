using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WizardEmporium.Common.SharedSwaggerConfig;
using WizardEmporium.User.Config;
using WizardEmporium.User.Repository;
using WizardEmporium.User.Service;

namespace WizardEmporium.User
{
    public class Startup
    {
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Wizard Emporium User API", Version = "v1" });
                c.OperationFilter<DescribeErrorTypeOnResponseOperationFilter>();
            });

            // Database config
            services.AddSingleton<IAccountRepo>(new AccountRepo(Configuration.GetConnectionString("AccountDB")));

            // Config
            services.Configure<RoleConfig>(Configuration.GetSection("Login"));

            // Services
            services.AddSingleton<IAccountService, AccountService>();
        }

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
                options.SwaggerEndpoint("swagger/v1/swagger.json", "Wizard Emporium User API");
                options.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
