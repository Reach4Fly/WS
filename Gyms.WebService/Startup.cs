using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Gyms.InfrastructureServices.Gateways.Database;
using Microsoft.EntityFrameworkCore;
using Gyms.ApplicationServices.GetGymPointListUseCase;
using Gyms.ApplicationServices.Ports.Gateways.Database;
using Gyms.ApplicationServices.Repositories;
using Gyms.DomainObjects.Ports;

namespace Gyms.WebService
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
            services.AddDbContext<GymContext>(opts =>
                opts.UseSqlite($"Filename={System.IO.Path.Combine(System.Environment.CurrentDirectory, "Gyms.db")}")
            );

            services.AddScoped<IGymDatabaseGateway, GymEFSqliteGateway>();

            services.AddScoped<DbGymPointRepository>();
            services.AddScoped<IReadOnlyGymPointRepository>(x => x.GetRequiredService<DbGymPointRepository>());
            services.AddScoped<IGymPointRepository>(x => x.GetRequiredService<DbGymPointRepository>());

            services.AddScoped<IGetGymPointListUseCase, GetGymPointListUseCase>();


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
