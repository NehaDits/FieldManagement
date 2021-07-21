using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FieldMgt.Core.Migrations
{
    public partial class fieldmgtcorenewaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "AddressTypeRef_FK",
                table: "AddressDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AddressDetails_City_CityId",
                table: "AddressDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AddressDetails_Country_CountryId",
                table: "AddressDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AddressDetails_State_StateId",
                table: "AddressDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_City_State_StateId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_EstimationDetails_Estimations_EstimationId",
                table: "EstimationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_EstimationDetails_ProductsMaster_ProductMasterId",
                table: "EstimationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Estimations_JobOrders_JobOrderID",
                table: "Estimations");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Orders_OrderId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_GlobalCodes_GlobalCodeCategories_GlobalCodeCategoryId",
                table: "GlobalCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_JobOrderRequirements_JobOrders_JobOrderId",
                table: "JobOrderRequirements");

            migrationBuilder.DropForeignKey(
                name: "LCLeadId_FK",
                table: "LeadCalls");

            migrationBuilder.DropForeignKey(
                name: "FK_LeadContacts_Leads_LeadId",
                table: "LeadContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Clients_ClientId",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "FK_Leads_ContactDetails_ContactDetailId",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "LBillingAddress_FK",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "LeadSource_FK",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "LeadStatus_FK",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "LPermaAddress_FK",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "NoteTypeRef_FK",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_ProductsMaster_ProductMasterId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderImplementationDetails_Orders_OrderId",
                table: "OrderImplementationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderImplementationDetails_ServiceProviderLocations_ServiceProviderLocationId",
                table: "OrderImplementationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderTransactions_Orders_OrderId",
                table: "OrderTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcurementProducts_Vendors_VendorId",
                table: "ProcurementProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductsMaster_ProductMasterId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsIssued_Orders_OrderId",
                table: "ProductsIssued");

            migrationBuilder.DropForeignKey(
                name: "PMCategory_FK",
                table: "ProductsMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProviderLocations_ServiceProviders_ServiceProviderId",
                table: "ServiceProviderLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_State_Country_CountryId",
                table: "State");

            migrationBuilder.AlterColumn<string>(
                name: "SPModifiedById",
                table: "ServiceProviders",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SPDeletedById",
                table: "ServiceProviders",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SPCreatedById",
                table: "ServiceProviders",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "OrderTransactions",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "ExceptionLogs",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExceptionId",
                table: "ExceptionLogs",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ErrorMessage",
                table: "ExceptionLogs",
                type: "nvarchar(500)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ErrorCode",
                table: "ExceptionLogs",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserTokens",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetUsers",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetUserRoles",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserRoles",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserLogins",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserClaims",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetRoles",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AddressDetails",
                type: "nvarchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AddressDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "AddressDetails",
                type: "nvarchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "AddressDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AddressDetails",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AddressDetails",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "AddressDetails",
                type: "nvarchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "AddressDetails",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AddressDetails_CreatedBy",
                table: "AddressDetails",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AddressDetails_DeletedBy",
                table: "AddressDetails",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AddressDetails_ModifiedBy",
                table: "AddressDetails",
                column: "ModifiedBy");

            migrationBuilder.AddForeignKey(
                name: "AddressCreatedBy_FK",
                table: "AddressDetails",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "AddressDeletedBy_FK",
                table: "AddressDetails",
                column: "DeletedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "AddressModifiedBy_FK",
                table: "AddressDetails",
                column: "ModifiedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "AddressTypeRef_FK",
                table: "AddressDetails",
                column: "AddressType",
                principalTable: "GlobalCodes",
                principalColumn: "GlobalCodeId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressDetails_City_CityId",
                table: "AddressDetails",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressDetails_Country_CountryId",
                table: "AddressDetails",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressDetails_State_StateId",
                table: "AddressDetails",
                column: "StateId",
                principalTable: "State",
                principalColumn: "StateId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_City_State_StateId",
                table: "City",
                column: "StateId",
                principalTable: "State",
                principalColumn: "StateId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_EstimationDetails_Estimations_EstimationId",
                table: "EstimationDetails",
                column: "EstimationId",
                principalTable: "Estimations",
                principalColumn: "EstimationId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_EstimationDetails_ProductsMaster_ProductMasterId",
                table: "EstimationDetails",
                column: "ProductMasterId",
                principalTable: "ProductsMaster",
                principalColumn: "ProductMasterId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Estimations_JobOrders_JobOrderID",
                table: "Estimations",
                column: "JobOrderID",
                principalTable: "JobOrders",
                principalColumn: "JobOrderId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Orders_OrderId",
                table: "Feedback",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_GlobalCodes_GlobalCodeCategories_GlobalCodeCategoryId",
                table: "GlobalCodes",
                column: "GlobalCodeCategoryId",
                principalTable: "GlobalCodeCategories",
                principalColumn: "GlobalCodeCategoryId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_JobOrderRequirements_JobOrders_JobOrderId",
                table: "JobOrderRequirements",
                column: "JobOrderId",
                principalTable: "JobOrders",
                principalColumn: "JobOrderId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "LCLeadId_FK",
                table: "LeadCalls",
                column: "LeadId",
                principalTable: "Leads",
                principalColumn: "LeadId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_LeadContacts_Leads_LeadId",
                table: "LeadContacts",
                column: "LeadId",
                principalTable: "Leads",
                principalColumn: "LeadId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Clients_ClientId",
                table: "Leads",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_ContactDetails_ContactDetailId",
                table: "Leads",
                column: "ContactDetailId",
                principalTable: "ContactDetails",
                principalColumn: "ContactDetailId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "LBillingAddress_FK",
                table: "Leads",
                column: "BillingAddressId",
                principalTable: "AddressDetails",
                principalColumn: "AddressDetailId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "LeadSource_FK",
                table: "Leads",
                column: "LeadSource",
                principalTable: "GlobalCodes",
                principalColumn: "GlobalCodeId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "LeadStatus_FK",
                table: "Leads",
                column: "LeadStatus",
                principalTable: "GlobalCodes",
                principalColumn: "GlobalCodeId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "LPermaAddress_FK",
                table: "Leads",
                column: "PermanentAddressId",
                principalTable: "AddressDetails",
                principalColumn: "AddressDetailId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "NoteTypeRef_FK",
                table: "Notes",
                column: "NoteTypeId",
                principalTable: "GlobalCodes",
                principalColumn: "GlobalCodeId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_ProductsMaster_ProductMasterId",
                table: "OrderDetails",
                column: "ProductMasterId",
                principalTable: "ProductsMaster",
                principalColumn: "ProductMasterId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderImplementationDetails_Orders_OrderId",
                table: "OrderImplementationDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderImplementationDetails_ServiceProviderLocations_ServiceProviderLocationId",
                table: "OrderImplementationDetails",
                column: "ServiceProviderLocationId",
                principalTable: "ServiceProviderLocations",
                principalColumn: "ServiceProviderLocationId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTransactions_Orders_OrderId",
                table: "OrderTransactions",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcurementProducts_Vendors_VendorId",
                table: "ProcurementProducts",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "VendorId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductsMaster_ProductMasterId",
                table: "Products",
                column: "ProductMasterId",
                principalTable: "ProductsMaster",
                principalColumn: "ProductMasterId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsIssued_Orders_OrderId",
                table: "ProductsIssued",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "PMCategory_FK",
                table: "ProductsMaster",
                column: "ProductCategory",
                principalTable: "GlobalCodes",
                principalColumn: "GlobalCodeId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProviderLocations_ServiceProviders_ServiceProviderId",
                table: "ServiceProviderLocations",
                column: "ServiceProviderId",
                principalTable: "ServiceProviders",
                principalColumn: "ServiceProviderId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_State_Country_CountryId",
                table: "State",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "AddressCreatedBy_FK",
                table: "AddressDetails");

            migrationBuilder.DropForeignKey(
                name: "AddressDeletedBy_FK",
                table: "AddressDetails");

            migrationBuilder.DropForeignKey(
                name: "AddressModifiedBy_FK",
                table: "AddressDetails");

            migrationBuilder.DropForeignKey(
                name: "AddressTypeRef_FK",
                table: "AddressDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AddressDetails_City_CityId",
                table: "AddressDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AddressDetails_Country_CountryId",
                table: "AddressDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AddressDetails_State_StateId",
                table: "AddressDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_City_State_StateId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_EstimationDetails_Estimations_EstimationId",
                table: "EstimationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_EstimationDetails_ProductsMaster_ProductMasterId",
                table: "EstimationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Estimations_JobOrders_JobOrderID",
                table: "Estimations");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_Orders_OrderId",
                table: "Feedback");

            migrationBuilder.DropForeignKey(
                name: "FK_GlobalCodes_GlobalCodeCategories_GlobalCodeCategoryId",
                table: "GlobalCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_JobOrderRequirements_JobOrders_JobOrderId",
                table: "JobOrderRequirements");

            migrationBuilder.DropForeignKey(
                name: "LCLeadId_FK",
                table: "LeadCalls");

            migrationBuilder.DropForeignKey(
                name: "FK_LeadContacts_Leads_LeadId",
                table: "LeadContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Clients_ClientId",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "FK_Leads_ContactDetails_ContactDetailId",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "LBillingAddress_FK",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "LeadSource_FK",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "LeadStatus_FK",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "LPermaAddress_FK",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "NoteTypeRef_FK",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_ProductsMaster_ProductMasterId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderImplementationDetails_Orders_OrderId",
                table: "OrderImplementationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderImplementationDetails_ServiceProviderLocations_ServiceProviderLocationId",
                table: "OrderImplementationDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderTransactions_Orders_OrderId",
                table: "OrderTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcurementProducts_Vendors_VendorId",
                table: "ProcurementProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductsMaster_ProductMasterId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsIssued_Orders_OrderId",
                table: "ProductsIssued");

            migrationBuilder.DropForeignKey(
                name: "PMCategory_FK",
                table: "ProductsMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProviderLocations_ServiceProviders_ServiceProviderId",
                table: "ServiceProviderLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_State_Country_CountryId",
                table: "State");

            migrationBuilder.DropIndex(
                name: "IX_AddressDetails_CreatedBy",
                table: "AddressDetails");

            migrationBuilder.DropIndex(
                name: "IX_AddressDetails_DeletedBy",
                table: "AddressDetails");

            migrationBuilder.DropIndex(
                name: "IX_AddressDetails_ModifiedBy",
                table: "AddressDetails");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AddressDetails");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AddressDetails");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "AddressDetails");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "AddressDetails");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AddressDetails");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AddressDetails");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "AddressDetails");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "AddressDetails");

            migrationBuilder.AlterColumn<string>(
                name: "SPModifiedById",
                table: "ServiceProviders",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SPDeletedById",
                table: "ServiceProviders",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SPCreatedById",
                table: "ServiceProviders",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeletedBy",
                table: "OrderTransactions",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ID",
                table: "ExceptionLogs",
                type: "nvarchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExceptionId",
                table: "ExceptionLogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ErrorMessage",
                table: "ExceptionLogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ErrorCode",
                table: "ExceptionLogs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserTokens",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetUsers",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetUserRoles",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserRoles",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserLogins",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AspNetUserClaims",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AspNetRoles",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "AspNetRoleClaims",
                type: "nvarchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)");

            migrationBuilder.AddForeignKey(
                name: "AddressTypeRef_FK",
                table: "AddressDetails",
                column: "AddressType",
                principalTable: "GlobalCodes",
                principalColumn: "GlobalCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressDetails_City_CityId",
                table: "AddressDetails",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressDetails_Country_CountryId",
                table: "AddressDetails",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressDetails_State_StateId",
                table: "AddressDetails",
                column: "StateId",
                principalTable: "State",
                principalColumn: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_City_State_StateId",
                table: "City",
                column: "StateId",
                principalTable: "State",
                principalColumn: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_EstimationDetails_Estimations_EstimationId",
                table: "EstimationDetails",
                column: "EstimationId",
                principalTable: "Estimations",
                principalColumn: "EstimationId");

            migrationBuilder.AddForeignKey(
                name: "FK_EstimationDetails_ProductsMaster_ProductMasterId",
                table: "EstimationDetails",
                column: "ProductMasterId",
                principalTable: "ProductsMaster",
                principalColumn: "ProductMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estimations_JobOrders_JobOrderID",
                table: "Estimations",
                column: "JobOrderID",
                principalTable: "JobOrders",
                principalColumn: "JobOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_Orders_OrderId",
                table: "Feedback",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_GlobalCodes_GlobalCodeCategories_GlobalCodeCategoryId",
                table: "GlobalCodes",
                column: "GlobalCodeCategoryId",
                principalTable: "GlobalCodeCategories",
                principalColumn: "GlobalCodeCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOrderRequirements_JobOrders_JobOrderId",
                table: "JobOrderRequirements",
                column: "JobOrderId",
                principalTable: "JobOrders",
                principalColumn: "JobOrderId");

            migrationBuilder.AddForeignKey(
                name: "LCLeadId_FK",
                table: "LeadCalls",
                column: "LeadId",
                principalTable: "Leads",
                principalColumn: "LeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeadContacts_Leads_LeadId",
                table: "LeadContacts",
                column: "LeadId",
                principalTable: "Leads",
                principalColumn: "LeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Clients_ClientId",
                table: "Leads",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_ContactDetails_ContactDetailId",
                table: "Leads",
                column: "ContactDetailId",
                principalTable: "ContactDetails",
                principalColumn: "ContactDetailId");

            migrationBuilder.AddForeignKey(
                name: "LBillingAddress_FK",
                table: "Leads",
                column: "BillingAddressId",
                principalTable: "AddressDetails",
                principalColumn: "AddressDetailId");

            migrationBuilder.AddForeignKey(
                name: "LeadSource_FK",
                table: "Leads",
                column: "LeadSource",
                principalTable: "GlobalCodes",
                principalColumn: "GlobalCodeId");

            migrationBuilder.AddForeignKey(
                name: "LeadStatus_FK",
                table: "Leads",
                column: "LeadStatus",
                principalTable: "GlobalCodes",
                principalColumn: "GlobalCodeId");

            migrationBuilder.AddForeignKey(
                name: "LPermaAddress_FK",
                table: "Leads",
                column: "PermanentAddressId",
                principalTable: "AddressDetails",
                principalColumn: "AddressDetailId");

            migrationBuilder.AddForeignKey(
                name: "NoteTypeRef_FK",
                table: "Notes",
                column: "NoteTypeId",
                principalTable: "GlobalCodes",
                principalColumn: "GlobalCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_ProductsMaster_ProductMasterId",
                table: "OrderDetails",
                column: "ProductMasterId",
                principalTable: "ProductsMaster",
                principalColumn: "ProductMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderImplementationDetails_Orders_OrderId",
                table: "OrderImplementationDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderImplementationDetails_ServiceProviderLocations_ServiceProviderLocationId",
                table: "OrderImplementationDetails",
                column: "ServiceProviderLocationId",
                principalTable: "ServiceProviderLocations",
                principalColumn: "ServiceProviderLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTransactions_Orders_OrderId",
                table: "OrderTransactions",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcurementProducts_Vendors_VendorId",
                table: "ProcurementProducts",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductsMaster_ProductMasterId",
                table: "Products",
                column: "ProductMasterId",
                principalTable: "ProductsMaster",
                principalColumn: "ProductMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsIssued_Orders_OrderId",
                table: "ProductsIssued",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "PMCategory_FK",
                table: "ProductsMaster",
                column: "ProductCategory",
                principalTable: "GlobalCodes",
                principalColumn: "GlobalCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProviderLocations_ServiceProviders_ServiceProviderId",
                table: "ServiceProviderLocations",
                column: "ServiceProviderId",
                principalTable: "ServiceProviders",
                principalColumn: "ServiceProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_State_Country_CountryId",
                table: "State",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "CountryId");
        }
    }
}
