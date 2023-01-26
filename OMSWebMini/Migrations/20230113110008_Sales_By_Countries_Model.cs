using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OMSWebMini.Migrations
{
    public partial class Sales_By_Countries_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.CreateTable(
				name: "SalesByCountries",
				columns: table => new
				{
					CountryName = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false),
					Sales = table.Column<decimal>(type: "decimal(18,10)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_SalesByCountries", x => x.CountryName);
				});
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.DropTable(
	  name: "SalesByCountries");
		}
    }
}
