using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Gyms.ApplicationServices.GetGymPointListUseCase;
using Gyms.ApplicationServices.Repositories;
using Gyms.DomainObjects.Ports;
using Gyms.DomainObjects;
using System.Collections.Generic;

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
            services.AddScoped<InMemoryGymPointRepository>(x => new InMemoryGymPointRepository(
                new List<GymPoint> {
                    new GymPoint() 
                    { 
                        Id = 1,
                        NameObject="Фитнес клуб «Зебра»",
                        NameZone="зал тренажерный",
                        District="Административный округ: Восточный административный округ",
                        Area="район Богородское",
                        Address="Краснобогатырская улица, дом 2, строение 1 ",
                        Email="",
                        WebSite="fitnes.ru  ",
    },
                    new GymPoint()
                    {
                       Id = 2,
                         NameObject="Физкультурно-оздоровительный комплекс «Центр Вешняки»",
                        NameZone="зал тренажерный",
                        District="Административный округ: Восточный административный округ  ",
                        Area="район Вешняки",
                        Address="Вешняковская улица, дом 29Д",
                        Email="mu_sdc@mail.ru",
                        WebSite="sport-vesh.ru "
                    }
                  
            }));
            services.AddScoped<IReadOnlyGymPointRepository>(x => x.GetRequiredService<InMemoryGymPointRepository>());
            services.AddScoped<IGymPointRepository>(x => x.GetRequiredService<InMemoryGymPointRepository>());

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
