using Microsoft.EntityFrameworkCore.Migrations;

namespace FieldMgt.Core.Migrations
{
    public partial class FieldMgtCorefgre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "VPCreatedBy_FK",
            //    table: "StaffOrganizations");

            //migrationBuilder.DropForeignKey(
            //    name: "VPDeletedBy_FK",
            //    table: "StaffOrganizations");

            //migrationBuilder.DropForeignKey(
            //    name: "VPModifiedBy_FK",
            //    table: "StaffOrganizations");

            //migrationBuilder.CreateTable(
            //    name: "PermissionTypes",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PermissionTypes", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RolePermissions",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Read = table.Column<bool>(type: "bit", nullable: false),
            //        Delete = table.Column<bool>(type: "bit", nullable: false),
            //        Update = table.Column<bool>(type: "bit", nullable: false),
            //        Add = table.Column<bool>(type: "bit", nullable: false),
            //        Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ApplicationRoleId = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RolePermissions", x => x.Id);
            //    });

            //migrationBuilder.AddForeignKey(
            //    name: "SOCreatedBy_FK",
            //    table: "StaffOrganizations",
            //    column: "CreatedBy",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "SODeletedBy_FK",
            //    table: "StaffOrganizations",
            //    column: "DeletedBy",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "SOModifiedBy_FK",
            //    table: "StaffOrganizations",
            //    column: "ModifiedBy",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "SOCreatedBy_FK",
                table: "StaffOrganizations");

            migrationBuilder.DropForeignKey(
                name: "SODeletedBy_FK",
                table: "StaffOrganizations");

            migrationBuilder.DropForeignKey(
                name: "SOModifiedBy_FK",
                table: "StaffOrganizations");

            migrationBuilder.DropTable(
                name: "PermissionTypes");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            //migrationBuilder.AddForeignKey(
            //    name: "VPCreatedBy_FK",
            //    table: "StaffOrganizations",
            //    column: "CreatedBy",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "VPDeletedBy_FK",
            //    table: "StaffOrganizations",
            //    column: "DeletedBy",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "VPModifiedBy_FK",
            //    table: "StaffOrganizations",
            //    column: "ModifiedBy",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
