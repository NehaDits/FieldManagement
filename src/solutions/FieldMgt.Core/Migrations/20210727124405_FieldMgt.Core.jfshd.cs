using Microsoft.EntityFrameworkCore.Migrations;

namespace FieldMgt.Core.Migrations
{
    public partial class FieldMgtCorejfshd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProviders_AspNetUsers_SPCreatedById",
                table: "ServiceProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProviders_AspNetUsers_SPDeletedById",
                table: "ServiceProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProviders_AspNetUsers_SPModifiedById",
                table: "ServiceProviders");

            migrationBuilder.DropIndex(
                name: "IX_ServiceProviders_SPCreatedById",
                table: "ServiceProviders");

            migrationBuilder.DropIndex(
                name: "IX_ServiceProviders_SPDeletedById",
                table: "ServiceProviders");

            migrationBuilder.DropIndex(
                name: "IX_ServiceProviders_SPModifiedById",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "SPCreatedById",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "SPDeletedById",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "SPModifiedById",
                table: "ServiceProviders");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviders_CreatedBy",
                table: "ServiceProviders",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviders_DeletedBy",
                table: "ServiceProviders",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviders_ModifiedBy",
                table: "ServiceProviders",
                column: "ModifiedBy");

            migrationBuilder.AddForeignKey(
                name: "SPCreated_FK",
                table: "ServiceProviders",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "SPDeleted_FK",
                table: "ServiceProviders",
                column: "DeletedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "SPModified_FK",
                table: "ServiceProviders",
                column: "ModifiedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "SPCreated_FK",
                table: "ServiceProviders");

            migrationBuilder.DropForeignKey(
                name: "SPDeleted_FK",
                table: "ServiceProviders");

            migrationBuilder.DropForeignKey(
                name: "SPModified_FK",
                table: "ServiceProviders");

            migrationBuilder.DropIndex(
                name: "IX_ServiceProviders_CreatedBy",
                table: "ServiceProviders");

            migrationBuilder.DropIndex(
                name: "IX_ServiceProviders_DeletedBy",
                table: "ServiceProviders");

            migrationBuilder.DropIndex(
                name: "IX_ServiceProviders_ModifiedBy",
                table: "ServiceProviders");

            migrationBuilder.AddColumn<string>(
                name: "SPCreatedById",
                table: "ServiceProviders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SPDeletedById",
                table: "ServiceProviders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SPModifiedById",
                table: "ServiceProviders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviders_SPCreatedById",
                table: "ServiceProviders",
                column: "SPCreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviders_SPDeletedById",
                table: "ServiceProviders",
                column: "SPDeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviders_SPModifiedById",
                table: "ServiceProviders",
                column: "SPModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProviders_AspNetUsers_SPCreatedById",
                table: "ServiceProviders",
                column: "SPCreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProviders_AspNetUsers_SPDeletedById",
                table: "ServiceProviders",
                column: "SPDeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProviders_AspNetUsers_SPModifiedById",
                table: "ServiceProviders",
                column: "SPModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
