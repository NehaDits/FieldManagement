using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FieldMgt.Core.Migrations
{
    public partial class FieldMgtCorevchjvdjc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StaffOrganizationId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StaffOrganizations",
                columns: table => new
                {
                    StaffOrganizationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffOrganizationName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    ContactDetailId = table.Column<int>(type: "int", nullable: true),
                    AddressDetailId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffOrganizations", x => x.StaffOrganizationId);
                    table.ForeignKey(
                        name: "FK_StaffOrganizations_AddressDetails_AddressDetailId",
                        column: x => x.AddressDetailId,
                        principalTable: "AddressDetails",
                        principalColumn: "AddressDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffOrganizations_ContactDetails_ContactDetailId",
                        column: x => x.ContactDetailId,
                        principalTable: "ContactDetails",
                        principalColumn: "ContactDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "SOCreatedBy_FK",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "SODeletedBy_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "SOModifiedBy_FK",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StaffOrganizationId",
                table: "AspNetUsers",
                column: "StaffOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffOrganizations_AddressDetailId",
                table: "StaffOrganizations",
                column: "AddressDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffOrganizations_ContactDetailId",
                table: "StaffOrganizations",
                column: "ContactDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffOrganizations_CreatedBy",
                table: "StaffOrganizations",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_StaffOrganizations_DeletedBy",
                table: "StaffOrganizations",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_StaffOrganizations_ModifiedBy",
                table: "StaffOrganizations",
                column: "ModifiedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_StaffOrganizations_StaffOrganizationId",
                table: "AspNetUsers",
                column: "StaffOrganizationId",
                principalTable: "StaffOrganizations",
                principalColumn: "StaffOrganizationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_StaffOrganizations_StaffOrganizationId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "StaffOrganizations");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StaffOrganizationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StaffOrganizationId",
                table: "AspNetUsers");
        }
    }
}
