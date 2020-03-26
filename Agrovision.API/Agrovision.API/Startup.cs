using System.Reflection;
using Agrovision.Data;
using Agrovision.Service;
using Agrovision.Service.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Agrovision.API
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();
            
            ConfigureDatabaseServices(services);
            ConfigureApplicationDependencies(services);
                
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Agrovision API", 
                    Description = "Sample API for Agrovision assignment",
                    Version = "v1" 
                    
                });
            });
        }

        private void ConfigureApplicationDependencies(IServiceCollection services)
        {
            services.AddScoped<IAgentService, AgentService>();
            services.AddScoped<IFieldService, FieldService>();
            services.AddScoped<ISprayerService, SprayerService>();
        }
        
        protected virtual void ConfigureDatabaseServices(IServiceCollection services)
        {
            services.AddDbContext<SprayCalcDbContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name)
                ));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors(policy => policy
                    .AllowAnyHeader()
                    .AllowAnyMethod()                    
                    .WithOrigins("http://localhost:4200")
                    .AllowCredentials());
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}
