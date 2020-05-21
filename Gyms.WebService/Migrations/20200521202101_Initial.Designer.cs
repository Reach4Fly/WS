﻿// <auto-generated />
using Gyms.InfrastructureServices.Gateways.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gyms.WebService.Migrations
{
    [DbContext(typeof(GymContext))]
    [Migration("20200521202101_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("Gyms.DomainObjects.GymPoint", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Area")
                        .HasColumnType("TEXT");

                    b.Property<string>("District")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("NameObject")
                        .HasColumnType("TEXT");

                    b.Property<string>("NameZone")
                        .HasColumnType("TEXT");

                    b.Property<string>("WebSite")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("GymPoints");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Address = "Краснобогатырская улица, дом 2, строение 1 ",
                            Area = "район Богородское",
                            District = "Административный округ: Восточный административный округ",
                            Email = "",
                            NameObject = "Фитнес клуб «Зебра»",
                            NameZone = "зал тренажерный",
                            WebSite = "fitnes.ru"
                        },
                        new
                        {
                            Id = 2L,
                            Address = "Вешняковская улица, дом 29Д",
                            Area = "район Вешняки",
                            District = "Административный округ: Восточный административный округ  ",
                            Email = "mu_sdc@mail.ru",
                            NameObject = "Физкультурно-оздоровительный комплекс «Центр Вешняки»",
                            NameZone = "зал тренажерный",
                            WebSite = "sport-vesh.ru "
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
