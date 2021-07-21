using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FieldMgt.Core.Migrations
{
    public partial class fieldmgtcorefjkekjwds2f : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "UserCreatedBy_FK",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "UserDeletedBy_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ContactDetails",
                columns: table => new
                {
                    ContactDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimaryPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlternatePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimaryEmail = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    AlternateEmail = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_ContactDetails", x => x.ContactDetailId);
                    table.ForeignKey(
                        name: "ContactDetailCreatedBy_FK",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ContactDetailDeletedBy_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ContactDetailModifiedBy_FK",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                    table.ForeignKey(
                        name: "CountryCreatedBy_FK",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "CountryDeletedBy_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "CountryModifiedBy_FK",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExceptionLogs",
                columns: table => new
                {
                    ExceptionLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExceptionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExceptionBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    ID = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    ExceptionOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionLogs", x => x.ExceptionLogId);
                    table.ForeignKey(
                        name: "FK_ExceptionLogs_AspNetUsers_ID",
                        column: x => x.ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GlobalCodeCategories",
                columns: table => new
                {
                    GlobalCodeCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GlobalCodeCategoryName = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    AllowAddDelete = table.Column<bool>(type: "bit", nullable: true),
                    AllowCodeNameEdit = table.Column<bool>(type: "bit", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_GlobalCodeCategories", x => x.GlobalCodeCategoryId);
                    table.ForeignKey(
                        name: "GlobalCodeCategoryCreatedBy_FK",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "GlobalCodeCategoryDeletedBy_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "GlobalCodeCategoryModifiedBy_FK",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Procurements",
                columns: table => new
                {
                    ProcurementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_Procurements", x => x.ProcurementId);
                    table.ForeignKey(
                        name: "ProcurementCreatedBy_FK",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ProcurementDeletedBy_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ProcurementModifiedBy_FK",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_State_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "StateCreatedBy_FK",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "StateDeletedBy_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "StateModifiedBy_FK",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GlobalCodes",
                columns: table => new
                {
                    GlobalCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GlobalCodeName = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    GlobalCodeCategoryId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_GlobalCodes", x => x.GlobalCodeId);
                    table.ForeignKey(
                        name: "FK_GlobalCodes_GlobalCodeCategories_GlobalCodeCategoryId",
                        column: x => x.GlobalCodeCategoryId,
                        principalTable: "GlobalCodeCategories",
                        principalColumn: "GlobalCodeCategoryId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "GlobalCodeCreatedBy_FK",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "GlobalCodeDeletedBy_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "GlobalCodeModifiedBy_FK",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_City", x => x.CityId);
                    table.ForeignKey(
                        name: "CityCreatedBy_FK",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "CityDeletedBy_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "CityModifiedBy_FK",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_City_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    NoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteDescription = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    NoteTypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_Notes", x => x.NoteId);
                    table.ForeignKey(
                        name: "NotesCreatedBy_FK",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "NotesDeletedTo_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "NotesModifiedBy_FK",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "NoteTypeRef_FK",
                        column: x => x.NoteTypeId,
                        principalTable: "GlobalCodes",
                        principalColumn: "GlobalCodeId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProductsMaster",
                columns: table => new
                {
                    ProductMasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    ProductCategory = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_ProductsMaster", x => x.ProductMasterId);
                    table.ForeignKey(
                        name: "PMCategory_FK",
                        column: x => x.ProductCategory,
                        principalTable: "GlobalCodes",
                        principalColumn: "GlobalCodeId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "PMCreatedBy_FK",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "PMDeleted_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "PMModifiedBy_FK",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AddressDetails",
                columns: table => new
                {
                    AddressDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    AddressType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressDetails", x => x.AddressDetailId);
                    table.ForeignKey(
                        name: "AddressTypeRef_FK",
                        column: x => x.AddressType,
                        principalTable: "GlobalCodes",
                        principalColumn: "GlobalCodeId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AddressDetails_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AddressDetails_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AddressDetails_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThresholdLimit = table.Column<int>(type: "int", nullable: true),
                    QuantityinStock = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    QuantityonOrder = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    ProductMasterId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_ProductsMaster_ProductMasterId",
                        column: x => x.ProductMasterId,
                        principalTable: "ProductsMaster",
                        principalColumn: "ProductMasterId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "ProductCreatedBy_FK",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ProductDeletedBy_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ProductModifiedBy_FK",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VendorProducts",
                columns: table => new
                {
                    VendorProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductMasterId = table.Column<int>(type: "int", nullable: true),
                    ProductPrice = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorProducts", x => x.VendorProductId);
                    table.ForeignKey(
                        name: "FK_VendorProducts_ProductsMaster_ProductMasterId",
                        column: x => x.ProductMasterId,
                        principalTable: "ProductsMaster",
                        principalColumn: "ProductMasterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "VPCreatedBy_FK",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "VPDeletedBy_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "VPModifiedBy_FK",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienyCompanyName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ClientDescription = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    ClientSource = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    ContactDetailId = table.Column<int>(type: "int", nullable: true),
                    PermanentAddressId = table.Column<int>(type: "int", nullable: true),
                    BillingAddressId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClientAddressAddressDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                    table.ForeignKey(
                        name: "ClientCreatedBy_FK",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ClientDeletedBy_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ClientModifiedBy_FK",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ClientSource_FK",
                        column: x => x.ClientSource,
                        principalTable: "GlobalCodes",
                        principalColumn: "GlobalCodeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_AddressDetails_ClientAddressAddressDetailId",
                        column: x => x.ClientAddressAddressDetailId,
                        principalTable: "AddressDetails",
                        principalColumn: "AddressDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clients_ContactDetails_ContactDetailId",
                        column: x => x.ContactDetailId,
                        principalTable: "ContactDetails",
                        principalColumn: "ContactDetailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviders",
                columns: table => new
                {
                    ServiceProviderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceProviderName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    ServiceProviderIncharge = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    ContactDetailId = table.Column<int>(type: "int", nullable: true),
                    PermanentAddressId = table.Column<int>(type: "int", nullable: true),
                    BillingAddressId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SPCreatedById = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    SPModifiedById = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    SPDeletedById = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviders", x => x.ServiceProviderId);
                    table.ForeignKey(
                        name: "FK_ServiceProviders_AspNetUsers_SPCreatedById",
                        column: x => x.SPCreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceProviders_AspNetUsers_SPDeletedById",
                        column: x => x.SPDeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceProviders_AspNetUsers_SPModifiedById",
                        column: x => x.SPModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceProviders_ContactDetails_ContactDetailId",
                        column: x => x.ContactDetailId,
                        principalTable: "ContactDetails",
                        principalColumn: "ContactDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "SPBillingAddress_FK",
                        column: x => x.BillingAddressId,
                        principalTable: "AddressDetails",
                        principalColumn: "AddressDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "SPPermaAddress_FK",
                        column: x => x.PermanentAddressId,
                        principalTable: "AddressDetails",
                        principalColumn: "AddressDetailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Designation = table.Column<int>(type: "int", nullable: true),
                    PermanentAddressId = table.Column<int>(type: "int", nullable: true),
                    CorrespondenceAddressId = table.Column<int>(type: "int", nullable: true),
                    ContactDetailId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.StaffId);
                    table.ForeignKey(
                        name: "CorrespondenceAddress_FK",
                        column: x => x.CorrespondenceAddressId,
                        principalTable: "AddressDetails",
                        principalColumn: "AddressDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Created_FK",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Deleted_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Designation_FK",
                        column: x => x.Designation,
                        principalTable: "GlobalCodes",
                        principalColumn: "GlobalCodeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Staffs_ContactDetails_ContactDetailId",
                        column: x => x.ContactDetailId,
                        principalTable: "ContactDetails",
                        principalColumn: "ContactDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Modified_FK",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "PermanentAddress_FK",
                        column: x => x.PermanentAddressId,
                        principalTable: "AddressDetails",
                        principalColumn: "AddressDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "StaffGender_FK",
                        column: x => x.Gender,
                        principalTable: "GlobalCodes",
                        principalColumn: "GlobalCodeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "UserId_FK",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    VendorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorCompanyName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    VendorOwnerorMD = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    VendorContactPersonName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    VendorGSTNumber = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    VendorAccountNumber = table.Column<string>(type: "nvarchar(12)", nullable: true),
                    VendorIFSCCode = table.Column<string>(type: "nvarchar(11)", nullable: true),
                    VendorBankName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    VendorBankBranch = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    PermanentAddressId = table.Column<int>(type: "int", nullable: true),
                    BillingAddressId = table.Column<int>(type: "int", nullable: true),
                    ContactDetailId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.VendorId);
                    table.ForeignKey(
                        name: "FK_Vendors_ContactDetails_ContactDetailId",
                        column: x => x.ContactDetailId,
                        principalTable: "ContactDetails",
                        principalColumn: "ContactDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "VendorBillingAddress_FK",
                        column: x => x.BillingAddressId,
                        principalTable: "AddressDetails",
                        principalColumn: "AddressDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "VendorCreatedBy_FK",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "VendorDeletedBy_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "VendorModifiedBy_FK",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "VendorPermaAddress_FK",
                        column: x => x.PermanentAddressId,
                        principalTable: "AddressDetails",
                        principalColumn: "AddressDetailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientContacts",
                columns: table => new
                {
                    ClientContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    AddressDetailId = table.Column<int>(type: "int", nullable: true),
                    ContactDetailId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientContacts", x => x.ClientContactId);
                    table.ForeignKey(
                        name: "ClientContactCreatedBy_FK",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ClientContactDeletedBy_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ClientContactGender_FK",
                        column: x => x.Gender,
                        principalTable: "GlobalCodes",
                        principalColumn: "GlobalCodeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ClientContactModifiedBy_FK",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientContacts_AddressDetails_AddressDetailId",
                        column: x => x.AddressDetailId,
                        principalTable: "AddressDetails",
                        principalColumn: "AddressDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientContacts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientContacts_ContactDetails_ContactDetailId",
                        column: x => x.ContactDetailId,
                        principalTable: "ContactDetails",
                        principalColumn: "ContactDetailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Leads",
                columns: table => new
                {
                    LeadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeadCompanyName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LeadDescription = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    LeadSource = table.Column<int>(type: "int", nullable: false),
                    LeadStatus = table.Column<int>(type: "int", nullable: false),
                    LeadStage = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    ContactDetailId = table.Column<int>(type: "int", nullable: false),
                    PermanentAddressId = table.Column<int>(type: "int", nullable: false),
                    BillingAddressId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leads", x => x.LeadId);
                    table.ForeignKey(
                        name: "FK_Leads_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Leads_ContactDetails_ContactDetailId",
                        column: x => x.ContactDetailId,
                        principalTable: "ContactDetails",
                        principalColumn: "ContactDetailId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "LBillingAddress_FK",
                        column: x => x.BillingAddressId,
                        principalTable: "AddressDetails",
                        principalColumn: "AddressDetailId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "LCreatedBy_FK",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "LDeletedBy_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "LeadSource_FK",
                        column: x => x.LeadSource,
                        principalTable: "GlobalCodes",
                        principalColumn: "GlobalCodeId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "LeadStage_FK",
                        column: x => x.LeadStage,
                        principalTable: "GlobalCodes",
                        principalColumn: "GlobalCodeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "LeadStatus_FK",
                        column: x => x.LeadStatus,
                        principalTable: "GlobalCodes",
                        principalColumn: "GlobalCodeId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "LModifiedBy_FK",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "LPermaAddress_FK",
                        column: x => x.PermanentAddressId,
                        principalTable: "AddressDetails",
                        principalColumn: "AddressDetailId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    OrderDescription = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    OrderStatus = table.Column<int>(type: "int", nullable: true),
                    ContactDetailId = table.Column<int>(type: "int", nullable: true),
                    PermanentAddressId = table.Column<int>(type: "int", nullable: true),
                    BillingAddressId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsComplete = table.Column<bool>(type: "bit", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssignedTo = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    OrderAmount = table.Column<decimal>(type: "decimal(16,2)", nullable: true),
                    AmountPaid = table.Column<decimal>(type: "decimal(16,2)", nullable: true),
                    BalanceAmount = table.Column<decimal>(type: "decimal(16,2)", nullable: true),
                    PaymentStatus = table.Column<int>(type: "int", nullable: true),
                    CompletionCertifcate = table.Column<string>(type: "nvarchar(255)", nullable: true),
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
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Orders_ContactDetails_ContactDetailId",
                        column: x => x.ContactDetailId,
                        principalTable: "ContactDetails",
                        principalColumn: "ContactDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "OrderAssignedTo_FK",
                        column: x => x.AssignedTo,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "OrderBillingAddress_FK",
                        column: x => x.BillingAddressId,
                        principalTable: "AddressDetails",
                        principalColumn: "AddressDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "OrderCreatedBy_FK",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "OrderDeletedBy_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "OrderModifiedBy_FK",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "OrderPaymentStatus_FK",
                        column: x => x.PaymentStatus,
                        principalTable: "GlobalCodes",
                        principalColumn: "GlobalCodeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "OrderPermaAddress_FK",
                        column: x => x.PermanentAddressId,
                        principalTable: "AddressDetails",
                        principalColumn: "AddressDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "OrderStatus_FK",
                        column: x => x.OrderStatus,
                        principalTable: "GlobalCodes",
                        principalColumn: "GlobalCodeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviderLocations",
                columns: table => new
                {
                    ServiceProviderLocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceProviderLocationName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    ServiceProviderLocationIncharge = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ContactDetailId = table.Column<int>(type: "int", nullable: true),
                    PermanentAddressId = table.Column<int>(type: "int", nullable: true),
                    BillingAddressId = table.Column<int>(type: "int", nullable: true),
                    ServiceProviderId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_ServiceProviderLocations", x => x.ServiceProviderLocationId);
                    table.ForeignKey(
                        name: "FK_ServiceProviderLocations_ContactDetails_ContactDetailId",
                        column: x => x.ContactDetailId,
                        principalTable: "ContactDetails",
                        principalColumn: "ContactDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceProviderLocations_ServiceProviders_ServiceProviderId",
                        column: x => x.ServiceProviderId,
                        principalTable: "ServiceProviders",
                        principalColumn: "ServiceProviderId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "SPLCreatedBy_FK",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "SPLDeleted_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "SPLModifiedBy_FK",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "SPLocationBillingAddress_FK",
                        column: x => x.BillingAddressId,
                        principalTable: "AddressDetails",
                        principalColumn: "AddressDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "SPLocationPermaAddress_FK",
                        column: x => x.PermanentAddressId,
                        principalTable: "AddressDetails",
                        principalColumn: "AddressDetailId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProcurementProducts",
                columns: table => new
                {
                    ProcurementItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductMasterId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_ProcurementProducts", x => x.ProcurementItemId);
                    table.ForeignKey(
                        name: "FK_ProcurementProducts_ProductsMaster_ProductMasterId",
                        column: x => x.ProductMasterId,
                        principalTable: "ProductsMaster",
                        principalColumn: "ProductMasterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProcurementProducts_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "JobOrders",
                columns: table => new
                {
                    JobOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobOrderDescription = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    LeadId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_JobOrders", x => x.JobOrderId);
                    table.ForeignKey(
                        name: "FK_JobOrders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobOrders_Leads_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Leads",
                        principalColumn: "LeadId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "JobOrderCreatedBy_FK",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "JobOrderDeletedBy_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "JobOrderModifiedBy_FK",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeadCalls",
                columns: table => new
                {
                    LeadCallId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    CallStatus = table.Column<int>(type: "int", nullable: true),
                    LeadId = table.Column<int>(type: "int", nullable: false),
                    CalledBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    CalledOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_LeadCalls", x => x.LeadCallId);
                    table.ForeignKey(
                        name: "LCCalledBy_FK",
                        column: x => x.CalledBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "LCLeadId_FK",
                        column: x => x.LeadId,
                        principalTable: "Leads",
                        principalColumn: "LeadId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "LCStatus_FK",
                        column: x => x.CallStatus,
                        principalTable: "GlobalCodes",
                        principalColumn: "GlobalCodeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeadContacts",
                columns: table => new
                {
                    LeadContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    AddressDetailId = table.Column<int>(type: "int", nullable: true),
                    ContactDetailId = table.Column<int>(type: "int", nullable: true),
                    LeadId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadContacts", x => x.LeadContactId);
                    table.ForeignKey(
                        name: "FK_LeadContacts_AddressDetails_AddressDetailId",
                        column: x => x.AddressDetailId,
                        principalTable: "AddressDetails",
                        principalColumn: "AddressDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeadContacts_ContactDetails_ContactDetailId",
                        column: x => x.ContactDetailId,
                        principalTable: "ContactDetails",
                        principalColumn: "ContactDetailId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeadContacts_Leads_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Leads",
                        principalColumn: "LeadId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "LCCreatedBy_FK",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "LCDeletedBy_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "LCGender_FK",
                        column: x => x.Gender,
                        principalTable: "GlobalCodes",
                        principalColumn: "GlobalCodeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "LCModifiedBy_FK",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    ActionTaken = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_Feedback", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FeedbackCreatedBy_FK",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FeedbackDeletedBy_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FeedbackModifiedBy_FK",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedback_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Maintenance",
                columns: table => new
                {
                    MaintenanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    MaintenanceType = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    TotalCost = table.Column<decimal>(type: "decimal(16,2)", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Maintenance", x => x.MaintenanceId);
                    table.ForeignKey(
                        name: "FK_Maintenance_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "MaintenanceCreatedBy_FK",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "MaintenanceDeletedBy_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "MaintenanceModifiedBy_FK",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "MaintenanceType_FK",
                        column: x => x.MaintenanceType,
                        principalTable: "GlobalCodes",
                        principalColumn: "GlobalCodeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderTransactions",
                columns: table => new
                {
                    OrderTransactiontId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(16,2)", nullable: true),
                    PaymentMethod = table.Column<int>(type: "int", nullable: true),
                    PaymentReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTransactions", x => x.OrderTransactiontId);
                    table.ForeignKey(
                        name: "FK_OrderTransactions_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "OrderTransactionCreatedBy_FK",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "OrderTransactionDeletedBy_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "OrderTransactionModifiedBy_FK",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductsIssued",
                columns: table => new
                {
                    ProductIssuedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuantityIssued = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    IssuedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    IssuedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsIssued", x => x.ProductIssuedId);
                    table.ForeignKey(
                        name: "FK_ProductsIssued_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "PIdeletedBy_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "PIModifiedBy_FK",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ProductIssuedBy_FK",
                        column: x => x.IssuedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderImplementationDetails",
                columns: table => new
                {
                    OrderImplementationDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ServiceProviderLocationId = table.Column<int>(type: "int", nullable: false),
                    PocName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TeamLead = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PocContactNumber = table.Column<string>(type: "nvarchar(14)", nullable: true),
                    TeamLeadContactNumber = table.Column<string>(type: "nvarchar(14)", nullable: true),
                    NumberofDayRequired = table.Column<int>(type: "int", nullable: true),
                    ProposedCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConfirmedCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsComplete = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderImplementationDetails", x => x.OrderImplementationDetailId);
                    table.ForeignKey(
                        name: "FK_OrderImplementationDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OrderImplementationDetails_ServiceProviderLocations_ServiceProviderLocationId",
                        column: x => x.ServiceProviderLocationId,
                        principalTable: "ServiceProviderLocations",
                        principalColumn: "ServiceProviderLocationId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Estimations",
                columns: table => new
                {
                    EstimationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstimationAmount = table.Column<decimal>(type: "decimal(16,2)", nullable: true),
                    JobOrderID = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Estimations", x => x.EstimationId);
                    table.ForeignKey(
                        name: "EstimationCreatedBy_FK",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "EstimationDeletedBy_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "EstimationModifiedBy_FK",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estimations_JobOrders_JobOrderID",
                        column: x => x.JobOrderID,
                        principalTable: "JobOrders",
                        principalColumn: "JobOrderId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "JobOrderRequirements",
                columns: table => new
                {
                    JobOrderRequirementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequirementDescription = table.Column<string>(type: "nvarchar(455)", nullable: true),
                    RequirementGatheredOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JobOrderId = table.Column<int>(type: "int", nullable: false),
                    RequirementGatheredBy = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_JobOrderRequirements", x => x.JobOrderRequirementId);
                    table.ForeignKey(
                        name: "FK_JobOrderRequirements_JobOrders_JobOrderId",
                        column: x => x.JobOrderId,
                        principalTable: "JobOrders",
                        principalColumn: "JobOrderId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "RequirementCreatedBy_FK",
                        column: x => x.RequirementGatheredBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "RequirementDeletedBy_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "RequirementModifiedBy_FK",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductMasterId = table.Column<int>(type: "int", nullable: false),
                    QuantityRequired = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    JobOrderId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderProductId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_JobOrders_JobOrderId",
                        column: x => x.JobOrderId,
                        principalTable: "JobOrders",
                        principalColumn: "JobOrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_ProductsMaster_ProductMasterId",
                        column: x => x.ProductMasterId,
                        principalTable: "ProductsMaster",
                        principalColumn: "ProductMasterId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "OPCreatedBy_FK",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "OPDeletedBy_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "OPModifiedBy_FK",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Quotations",
                columns: table => new
                {
                    QuotationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerDesiredPrice = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    InitialQuotedPrice = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    LastQuotedPrice = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    MinPossiblePrice = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    JobOrderId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
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
                    table.PrimaryKey("PK_Quotations", x => x.QuotationId);
                    table.ForeignKey(
                        name: "FK_Quotations_JobOrders_JobOrderId",
                        column: x => x.JobOrderId,
                        principalTable: "JobOrders",
                        principalColumn: "JobOrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Quotations_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "QuotationCreatedBy_FK",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "QuotationDeletedBy_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "QuotationModifiedBy_FK",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EstimationDetails",
                columns: table => new
                {
                    EstimationDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductMasterId = table.Column<int>(type: "int", nullable: false),
                    ProductUnitPrice = table.Column<decimal>(type: "decimal(16,2)", nullable: true),
                    QuantityRequired = table.Column<decimal>(type: "decimal(16,2)", nullable: true),
                    EstimationId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_EstimationDetails", x => x.EstimationDetailId);
                    table.ForeignKey(
                        name: "EstimationDetailCreatedBy_FK",
                        column: x => x.CreatedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "EstimationDetailDeletedBy_FK",
                        column: x => x.DeletedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "EstimationDetailModifiedBy_FK",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EstimationDetails_Estimations_EstimationId",
                        column: x => x.EstimationId,
                        principalTable: "Estimations",
                        principalColumn: "EstimationId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EstimationDetails_ProductsMaster_ProductMasterId",
                        column: x => x.ProductMasterId,
                        principalTable: "ProductsMaster",
                        principalColumn: "ProductMasterId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressDetails_AddressType",
                table: "AddressDetails",
                column: "AddressType");

            migrationBuilder.CreateIndex(
                name: "IX_AddressDetails_CityId",
                table: "AddressDetails",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressDetails_CountryId",
                table: "AddressDetails",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressDetails_StateId",
                table: "AddressDetails",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CreatedBy",
                table: "AspNetUsers",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DeletedBy",
                table: "AspNetUsers",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_City_CreatedBy",
                table: "City",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_City_DeletedBy",
                table: "City",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_City_ModifiedBy",
                table: "City",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_City_StateId",
                table: "City",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientContacts_AddressDetailId",
                table: "ClientContacts",
                column: "AddressDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientContacts_ClientId",
                table: "ClientContacts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientContacts_ContactDetailId",
                table: "ClientContacts",
                column: "ContactDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientContacts_CreatedBy",
                table: "ClientContacts",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ClientContacts_DeletedBy",
                table: "ClientContacts",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ClientContacts_Gender",
                table: "ClientContacts",
                column: "Gender");

            migrationBuilder.CreateIndex(
                name: "IX_ClientContacts_ModifiedBy",
                table: "ClientContacts",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientAddressAddressDetailId",
                table: "Clients",
                column: "ClientAddressAddressDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientSource",
                table: "Clients",
                column: "ClientSource");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ContactDetailId",
                table: "Clients",
                column: "ContactDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CreatedBy",
                table: "Clients",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_DeletedBy",
                table: "Clients",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ModifiedBy",
                table: "Clients",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_CreatedBy",
                table: "ContactDetails",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_DeletedBy",
                table: "ContactDetails",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_ModifiedBy",
                table: "ContactDetails",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Country_CreatedBy",
                table: "Country",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Country_DeletedBy",
                table: "Country",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Country_ModifiedBy",
                table: "Country",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EstimationDetails_CreatedBy",
                table: "EstimationDetails",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EstimationDetails_DeletedBy",
                table: "EstimationDetails",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EstimationDetails_EstimationId",
                table: "EstimationDetails",
                column: "EstimationId");

            migrationBuilder.CreateIndex(
                name: "IX_EstimationDetails_ModifiedBy",
                table: "EstimationDetails",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EstimationDetails_ProductMasterId",
                table: "EstimationDetails",
                column: "ProductMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Estimations_CreatedBy",
                table: "Estimations",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Estimations_DeletedBy",
                table: "Estimations",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Estimations_JobOrderID",
                table: "Estimations",
                column: "JobOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Estimations_ModifiedBy",
                table: "Estimations",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionLogs_ID",
                table: "ExceptionLogs",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_CreatedBy",
                table: "Feedback",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_DeletedBy",
                table: "Feedback",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_ModifiedBy",
                table: "Feedback",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_OrderId",
                table: "Feedback",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalCodeCategories_CreatedBy",
                table: "GlobalCodeCategories",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalCodeCategories_DeletedBy",
                table: "GlobalCodeCategories",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalCodeCategories_ModifiedBy",
                table: "GlobalCodeCategories",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalCodes_CreatedBy",
                table: "GlobalCodes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalCodes_DeletedBy",
                table: "GlobalCodes",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalCodes_GlobalCodeCategoryId",
                table: "GlobalCodes",
                column: "GlobalCodeCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalCodes_ModifiedBy",
                table: "GlobalCodes",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_JobOrderRequirements_DeletedBy",
                table: "JobOrderRequirements",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_JobOrderRequirements_JobOrderId",
                table: "JobOrderRequirements",
                column: "JobOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOrderRequirements_ModifiedBy",
                table: "JobOrderRequirements",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_JobOrderRequirements_RequirementGatheredBy",
                table: "JobOrderRequirements",
                column: "RequirementGatheredBy");

            migrationBuilder.CreateIndex(
                name: "IX_JobOrders_ClientId",
                table: "JobOrders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOrders_CreatedBy",
                table: "JobOrders",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_JobOrders_DeletedBy",
                table: "JobOrders",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_JobOrders_LeadId",
                table: "JobOrders",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOrders_ModifiedBy",
                table: "JobOrders",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_LeadCalls_CalledBy",
                table: "LeadCalls",
                column: "CalledBy");

            migrationBuilder.CreateIndex(
                name: "IX_LeadCalls_CallStatus",
                table: "LeadCalls",
                column: "CallStatus");

            migrationBuilder.CreateIndex(
                name: "IX_LeadCalls_LeadId",
                table: "LeadCalls",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadContacts_AddressDetailId",
                table: "LeadContacts",
                column: "AddressDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadContacts_ContactDetailId",
                table: "LeadContacts",
                column: "ContactDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadContacts_CreatedBy",
                table: "LeadContacts",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_LeadContacts_DeletedBy",
                table: "LeadContacts",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_LeadContacts_Gender",
                table: "LeadContacts",
                column: "Gender");

            migrationBuilder.CreateIndex(
                name: "IX_LeadContacts_LeadId",
                table: "LeadContacts",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadContacts_ModifiedBy",
                table: "LeadContacts",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_BillingAddressId",
                table: "Leads",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_ClientId",
                table: "Leads",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_ContactDetailId",
                table: "Leads",
                column: "ContactDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_CreatedBy",
                table: "Leads",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_DeletedBy",
                table: "Leads",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_LeadSource",
                table: "Leads",
                column: "LeadSource");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_LeadStage",
                table: "Leads",
                column: "LeadStage");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_LeadStatus",
                table: "Leads",
                column: "LeadStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_ModifiedBy",
                table: "Leads",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_PermanentAddressId",
                table: "Leads",
                column: "PermanentAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_CreatedBy",
                table: "Maintenance",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_DeletedBy",
                table: "Maintenance",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_MaintenanceType",
                table: "Maintenance",
                column: "MaintenanceType");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_ModifiedBy",
                table: "Maintenance",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_OrderId",
                table: "Maintenance",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_CreatedBy",
                table: "Notes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_DeletedBy",
                table: "Notes",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ModifiedBy",
                table: "Notes",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_NoteTypeId",
                table: "Notes",
                column: "NoteTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_CreatedBy",
                table: "OrderDetails",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_DeletedBy",
                table: "OrderDetails",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_JobOrderId",
                table: "OrderDetails",
                column: "JobOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ModifiedBy",
                table: "OrderDetails",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductMasterId",
                table: "OrderDetails",
                column: "ProductMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderImplementationDetails_OrderId",
                table: "OrderImplementationDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderImplementationDetails_ServiceProviderLocationId",
                table: "OrderImplementationDetails",
                column: "ServiceProviderLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AssignedTo",
                table: "Orders",
                column: "AssignedTo");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BillingAddressId",
                table: "Orders",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ContactDetailId",
                table: "Orders",
                column: "ContactDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CreatedBy",
                table: "Orders",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeletedBy",
                table: "Orders",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ModifiedBy",
                table: "Orders",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatus",
                table: "Orders",
                column: "OrderStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentStatus",
                table: "Orders",
                column: "PaymentStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PermanentAddressId",
                table: "Orders",
                column: "PermanentAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTransactions_CreatedBy",
                table: "OrderTransactions",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTransactions_DeletedBy",
                table: "OrderTransactions",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTransactions_ModifiedBy",
                table: "OrderTransactions",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTransactions_OrderId",
                table: "OrderTransactions",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcurementProducts_ProductMasterId",
                table: "ProcurementProducts",
                column: "ProductMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcurementProducts_VendorId",
                table: "ProcurementProducts",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Procurements_CreatedBy",
                table: "Procurements",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Procurements_DeletedBy",
                table: "Procurements",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Procurements_ModifiedBy",
                table: "Procurements",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedBy",
                table: "Products",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DeletedBy",
                table: "Products",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ModifiedBy",
                table: "Products",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductMasterId",
                table: "Products",
                column: "ProductMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsIssued_DeletedBy",
                table: "ProductsIssued",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsIssued_IssuedBy",
                table: "ProductsIssued",
                column: "IssuedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsIssued_ModifiedBy",
                table: "ProductsIssued",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsIssued_OrderId",
                table: "ProductsIssued",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsMaster_CreatedBy",
                table: "ProductsMaster",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsMaster_DeletedBy",
                table: "ProductsMaster",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsMaster_ModifiedBy",
                table: "ProductsMaster",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsMaster_ProductCategory",
                table: "ProductsMaster",
                column: "ProductCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_CreatedBy",
                table: "Quotations",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_DeletedBy",
                table: "Quotations",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_JobOrderId",
                table: "Quotations",
                column: "JobOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_ModifiedBy",
                table: "Quotations",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_OrderId",
                table: "Quotations",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderLocations_BillingAddressId",
                table: "ServiceProviderLocations",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderLocations_ContactDetailId",
                table: "ServiceProviderLocations",
                column: "ContactDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderLocations_CreatedBy",
                table: "ServiceProviderLocations",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderLocations_DeletedBy",
                table: "ServiceProviderLocations",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderLocations_ModifiedBy",
                table: "ServiceProviderLocations",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderLocations_PermanentAddressId",
                table: "ServiceProviderLocations",
                column: "PermanentAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviderLocations_ServiceProviderId",
                table: "ServiceProviderLocations",
                column: "ServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviders_BillingAddressId",
                table: "ServiceProviders",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviders_ContactDetailId",
                table: "ServiceProviders",
                column: "ContactDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProviders_PermanentAddressId",
                table: "ServiceProviders",
                column: "PermanentAddressId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_ContactDetailId",
                table: "Staffs",
                column: "ContactDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_CorrespondenceAddressId",
                table: "Staffs",
                column: "CorrespondenceAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_CreatedBy",
                table: "Staffs",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_DeletedBy",
                table: "Staffs",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_Designation",
                table: "Staffs",
                column: "Designation");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_Gender",
                table: "Staffs",
                column: "Gender");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_ModifiedBy",
                table: "Staffs",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_PermanentAddressId",
                table: "Staffs",
                column: "PermanentAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_UserId",
                table: "Staffs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryId",
                table: "State",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_State_CreatedBy",
                table: "State",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_State_DeletedBy",
                table: "State",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_State_ModifiedBy",
                table: "State",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_VendorProducts_CreatedBy",
                table: "VendorProducts",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_VendorProducts_DeletedBy",
                table: "VendorProducts",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_VendorProducts_ModifiedBy",
                table: "VendorProducts",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_VendorProducts_ProductMasterId",
                table: "VendorProducts",
                column: "ProductMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_BillingAddressId",
                table: "Vendors",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_ContactDetailId",
                table: "Vendors",
                column: "ContactDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_CreatedBy",
                table: "Vendors",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_DeletedBy",
                table: "Vendors",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_ModifiedBy",
                table: "Vendors",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_PermanentAddressId",
                table: "Vendors",
                column: "PermanentAddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ClientContacts");

            migrationBuilder.DropTable(
                name: "EstimationDetails");

            migrationBuilder.DropTable(
                name: "ExceptionLogs");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "JobOrderRequirements");

            migrationBuilder.DropTable(
                name: "LeadCalls");

            migrationBuilder.DropTable(
                name: "LeadContacts");

            migrationBuilder.DropTable(
                name: "Maintenance");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "OrderImplementationDetails");

            migrationBuilder.DropTable(
                name: "OrderTransactions");

            migrationBuilder.DropTable(
                name: "ProcurementProducts");

            migrationBuilder.DropTable(
                name: "Procurements");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductsIssued");

            migrationBuilder.DropTable(
                name: "Quotations");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "VendorProducts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Estimations");

            migrationBuilder.DropTable(
                name: "ServiceProviderLocations");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductsMaster");

            migrationBuilder.DropTable(
                name: "JobOrders");

            migrationBuilder.DropTable(
                name: "ServiceProviders");

            migrationBuilder.DropTable(
                name: "Leads");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "AddressDetails");

            migrationBuilder.DropTable(
                name: "ContactDetails");

            migrationBuilder.DropTable(
                name: "GlobalCodes");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "GlobalCodeCategories");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
