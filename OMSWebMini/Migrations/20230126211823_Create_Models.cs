using Microsoft.EntityFrameworkCore.Migrations;

namespace OMSWebMini.Migrations
{
	public partial class Create_Models : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "CustomersByCountries",
				columns: table => new
				{
					CountryName = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false),
					CustomersCount = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_CustomersByCountries", x => x.CountryName);
				});

			migrationBuilder.CreateTable(
				   name: "ProductsByCategories",
				   columns: table => new
				   {
					   CategoryName = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false),
					   ProductsCount = table.Column<int>(type: "int", nullable: false)
				   },
				   constraints: table =>
				   {
					   table.PrimaryKey("PK_ProductsByCategories", x => x.CategoryName);
				   });

			migrationBuilder.CreateTable(
				name: "PurchasesByCustomers",
				columns: table => new
				{
					CompanyName = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false),
					Purchases = table.Column<decimal>(type: "decimal(18,10)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_PurchasesByCustomers", x => x.CompanyName);
				});

			migrationBuilder.CreateTable(
			  name: "SalesByEmployees",
			  columns: table => new
			  {
				  EmployeeName = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: false),
				  Sales = table.Column<decimal>(type: "decimal(18,10)", nullable: false)
			  },
			  constraints: table =>
			  {
				  table.PrimaryKey("PK_SalesByEmployees", x => x.EmployeeName);
			  });
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				 name: "CustomersByCountries");

			migrationBuilder.DropTable(
				name: "ProductsByCategories");

			migrationBuilder.DropTable(
				name: "PurchasesByCustomers");

			migrationBuilder.DropTable(
				name: "SalesByEmployees");

		}
	}
}
