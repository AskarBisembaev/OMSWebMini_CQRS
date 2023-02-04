using Microsoft.EntityFrameworkCore.Migrations;

namespace OMSWebMini.Migrations
{
	public partial class Summary : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Summary",
				columns: table => new
				{
					id = table.Column<int>(type: "int", nullable: false),
					OverallSalesSum = table.Column<int>(type: "int", nullable: false),
					OverallOrdersQuantity = table.Column<int>(type: "int", nullable: false),
					MaxCheck = table.Column<int>(type: "int", nullable: false),
					MinCheck = table.Column<int>(type: "int", nullable: false),
					Average = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Summary", x => x.id);
				});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Summaries");
		}
	}
}
