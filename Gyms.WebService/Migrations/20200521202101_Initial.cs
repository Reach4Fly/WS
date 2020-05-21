using Microsoft.EntityFrameworkCore.Migrations;

namespace Gyms.WebService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GymPoints",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameObject = table.Column<string>(nullable: true),
                    NameZone = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymPoints", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "GymPoints",
                columns: new[] { "Id", "Address", "Area", "District", "Email", "NameObject", "NameZone", "WebSite" },
                values: new object[] { 1L, "Краснобогатырская улица, дом 2, строение 1 ", "район Богородское", "Административный округ: Восточный административный округ", "", "Фитнес клуб «Зебра»", "зал тренажерный", "fitnes.ru" });

            migrationBuilder.InsertData(
                table: "GymPoints",
                columns: new[] { "Id", "Address", "Area", "District", "Email", "NameObject", "NameZone", "WebSite" },
                values: new object[] { 2L, "Вешняковская улица, дом 29Д", "район Вешняки", "Административный округ: Восточный административный округ  ", "mu_sdc@mail.ru", "Физкультурно-оздоровительный комплекс «Центр Вешняки»", "зал тренажерный", "sport-vesh.ru " });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GymPoints");
        }
    }
}
