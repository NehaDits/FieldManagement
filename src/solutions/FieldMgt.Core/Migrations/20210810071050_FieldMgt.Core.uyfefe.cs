using Microsoft.EntityFrameworkCore.Migrations;

namespace FieldMgt.Core.Migrations
{
    public partial class FieldMgtCoreuyfefe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressDetailId",
                table: "JobOrders",
                type: "int",
                nullable: true);

            

            migrationBuilder.CreateIndex(
                name: "IX_JobOrders_AddressDetailId",
                table: "JobOrders",
                column: "AddressDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOrders_AddressDetails_AddressDetailId",
                table: "JobOrders",
                column: "AddressDetailId",
                principalTable: "AddressDetails",
                principalColumn: "AddressDetailId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOrders_AddressDetails_AddressDetailId",
                table: "JobOrders");

            migrationBuilder.DropIndex(
                name: "IX_JobOrders_AddressDetailId",
                table: "JobOrders");

            migrationBuilder.DropColumn(
                name: "AddressDetailId",
                table: "JobOrders");

            
        }
    }
}
