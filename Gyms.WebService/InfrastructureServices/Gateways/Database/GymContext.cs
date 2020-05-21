using Microsoft.EntityFrameworkCore;
using Gyms.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gyms.InfrastructureServices.Gateways.Database
{
    public class GymContext : DbContext
    {
        public DbSet<GymPoint> GymPoints { get; set; }

        public GymContext(DbContextOptions options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            FillTestData(modelBuilder);
        }
        private void FillTestData(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<GymPoint>().HasData(
                new
  {
                    Id = 1L,
                    NameObject = "Фитнес клуб «Зебра»",
                    NameZone = "зал тренажерный",
                    District = "Административный округ: Восточный административный округ",
                    Area = "район Богородское",
                    Address = "Краснобогатырская улица, дом 2, строение 1 ",
                    Email = "",
                    WebSite = "fitnes.ru"

                },
                new
                {
                    Id = 2L,
                    NameObject = "Физкультурно-оздоровительный комплекс «Центр Вешняки»",
                    NameZone = "зал тренажерный",
                    District = "Административный округ: Восточный административный округ  ",
                    Area = "район Вешняки",
                    Address = "Вешняковская улица, дом 29Д",
                    Email = "mu_sdc@mail.ru",
                    WebSite = "sport-vesh.ru "
                }
                
            );
        }
    }
}
