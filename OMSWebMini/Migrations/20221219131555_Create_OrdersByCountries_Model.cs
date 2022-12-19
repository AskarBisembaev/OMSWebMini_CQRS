using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OMSWebMini.Migrations
{
    public partial class Create_OrdersByCountries_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrdersByCountries",
                columns: table => new
                {
					CountryName = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false),
                    OrdersCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersByCountries", x => x.CountryName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdersByCountries");
        }
    }
}
