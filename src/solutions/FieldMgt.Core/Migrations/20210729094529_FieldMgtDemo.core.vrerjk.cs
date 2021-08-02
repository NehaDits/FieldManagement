using Microsoft.EntityFrameworkCore.Migrations;

namespace FieldMgt.Core.Migrations
{
    public partial class FieldMgtDemocorevrerjk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "SPLocationPermaAddress_FK",
                table: "ServiceProviderLocations");

            migrationBuilder.DropIndex(
                name: "IX_ServiceProviderLocations_PermanentAddressId",
                table: "ServiceProviderLocations");

            migrationBuilder.DropColumn(
                name: "PermanentAddressId",
                table: "ServiceProviderLocations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PermanentAddressId",
                table: "ServiceProviderLocations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderLocations_PermanentAddressId",
                table: "ServiceProviderLocations",
                column: "PermanentAddressId");

            migrationBuilder.AddForeignKey(
                name: "SPLocationPermaAddress_FK",
                table: "ServiceProviderLocations",
                column: "PermanentAddressId",
                principalTable: "AddressDetails",
                principalColumn: "AddressDetailId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
