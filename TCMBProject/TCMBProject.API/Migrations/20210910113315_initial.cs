using Microsoft.EntityFrameworkCore.Migrations;

namespace TCMBProject.API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrossRateUsd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForexBuying = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ForexSelling = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BanknoteBuying = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BanknoteSelling = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
