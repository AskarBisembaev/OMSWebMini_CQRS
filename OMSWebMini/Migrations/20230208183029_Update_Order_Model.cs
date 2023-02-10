using Microsoft.EntityFrameworkCore.Migrations;

namespace OMSWebMini.Migrations
{
    public partial class Update_Order_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeliveryDate",
                table: "Orders",
                newName: "CompletedDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompletedDate",
                table: "Orders",
                newName: "DeliveryDate");
        }
    }
}
