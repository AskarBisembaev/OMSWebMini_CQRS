using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OMSWebMini.Migrations
{
    public partial class Sales_By_Categories_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalesByCategories",
                columns: table => new
                {
                    CategoryName = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false),
                    Sales = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesByCategories", x => x.CategoryName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesByCategories");
        }
    }
}
