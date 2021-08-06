using Microsoft.EntityFrameworkCore.Migrations;

namespace FieldMgt.Core.Migrations
{
    public partial class FieldMgtDemocorevrer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Clients_ClientId",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "SPLocationBillingAddress_FK",
                table: "ServiceProviderLocations");

            migrationBuilder.RenameColumn(
                name: "BillingAddressId",
                table: "ServiceProviderLocations",
                newName: "AddressDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceProviderLocations_BillingAddressId",
                table: "ServiceProviderLocations",
                newName: "IX_ServiceProviderLocations_AddressDetailId");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Leads",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Clients_ClientId",
                table: "Leads",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProviderLocations_AddressDetails_AddressDetailId",
                table: "ServiceProviderLocations",
                column: "AddressDetailId",
                principalTable: "AddressDetails",
                principalColumn: "AddressDetailId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Clients_ClientId",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProviderLocations_AddressDetails_AddressDetailId",
                table: "ServiceProviderLocations");

            migrationBuilder.RenameColumn(
                name: "AddressDetailId",
                table: "ServiceProviderLocations",
                newName: "BillingAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceProviderLocations_AddressDetailId",
                table: "ServiceProviderLocations",
                newName: "IX_ServiceProviderLocations_BillingAddressId");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Leads",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Clients_ClientId",
                table: "Leads",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "SPLocationBillingAddress_FK",
                table: "ServiceProviderLocations",
                column: "BillingAddressId",
                principalTable: "AddressDetails",
                principalColumn: "AddressDetailId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
