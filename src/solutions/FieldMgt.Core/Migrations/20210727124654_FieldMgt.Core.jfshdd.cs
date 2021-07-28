using Microsoft.EntityFrameworkCore.Migrations;

namespace FieldMgt.Core.Migrations
{
    public partial class FieldMgtCorejfshdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "ServiceProviders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "ServiceProviders",
                type: "int",
                nullable: true);
        }
    }
}
