using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCMBProject.API.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrencyModels",
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
                    BanknoteSelling = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyModels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyModels");
        }
    }
}
