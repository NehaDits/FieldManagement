using Microsoft.EntityFrameworkCore.Migrations;

namespace FieldMgt.Core.Migrations
{
    public partial class FieldMgtDemocorevrerjko : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Clients_ClientId",
                table: "Leads");

            migrationBuilder.DropIndex(
                name: "IX_Leads_ClientId",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Leads");

            migrationBuilder.AddColumn<int>(
                name: "LeadId",
                table: "Clients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_LeadId",
                table: "Clients",
                column: "LeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Leads_LeadId",
                table: "Clients",
                column: "LeadId",
                principalTable: "Leads",
                principalColumn: "LeadId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Leads_LeadId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_LeadId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "LeadId",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Leads",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Leads_ClientId",
                table: "Leads",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Clients_ClientId",
                table: "Leads",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
