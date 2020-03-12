using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mmu.IdentityProvider.WebApi.Areas.IdentityServer.Operational.DataAccess.Migrations
{
    public partial class InitialIdentityServerPersistedGrantDbMigration : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "DeviceCodes",
                "IdentityOperational");

            migrationBuilder.DropTable(
                "PersistedGrants",
                "IdentityOperational");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                "IdentityOperational");

            migrationBuilder.CreateTable(
                "DeviceCodes",
                schema: "IdentityOperational",
                columns: table => new
                {
                    UserCode = table.Column<string>(maxLength: 200),
                    DeviceCode = table.Column<string>(maxLength: 200),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200),
                    CreationTime = table.Column<DateTime>(),
                    Expiration = table.Column<DateTime>(),
                    Data = table.Column<string>(maxLength: 50000)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCodes", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                "PersistedGrants",
                schema: "IdentityOperational",
                columns: table => new
                {
                    Key = table.Column<string>(maxLength: 200),
                    Type = table.Column<string>(maxLength: 50),
                    SubjectId = table.Column<string>(maxLength: 200, nullable: true),
                    ClientId = table.Column<string>(maxLength: 200),
                    CreationTime = table.Column<DateTime>(),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Data = table.Column<string>(maxLength: 50000)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.Key);
                });

            migrationBuilder.CreateIndex(
                "IX_DeviceCodes_DeviceCode",
                schema: "IdentityOperational",
                table: "DeviceCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_DeviceCodes_Expiration",
                schema: "IdentityOperational",
                table: "DeviceCodes",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                "IX_PersistedGrants_Expiration",
                schema: "IdentityOperational",
                table: "PersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                "IX_PersistedGrants_SubjectId_ClientId_Type",
                schema: "IdentityOperational",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });
        }
    }
}