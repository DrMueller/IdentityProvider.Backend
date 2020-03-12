using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mmu.IdentityProvider.WebApi.Areas.IdentityServer.Config.DataAccess.Migrations
{
    public partial class InitialIdentityServerPersistedGrantDbMigration : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "ApiClaims",
                "IdentityConfiguration");

            migrationBuilder.DropTable(
                "ApiProperties",
                "IdentityConfiguration");

            migrationBuilder.DropTable(
                "ApiScopeClaims",
                "IdentityConfiguration");

            migrationBuilder.DropTable(
                "ApiSecrets",
                "IdentityConfiguration");

            migrationBuilder.DropTable(
                "ClientClaims",
                "IdentityConfiguration");

            migrationBuilder.DropTable(
                "ClientCorsOrigins",
                "IdentityConfiguration");

            migrationBuilder.DropTable(
                "ClientGrantTypes",
                "IdentityConfiguration");

            migrationBuilder.DropTable(
                "ClientIdPRestrictions",
                "IdentityConfiguration");

            migrationBuilder.DropTable(
                "ClientPostLogoutRedirectUris",
                "IdentityConfiguration");

            migrationBuilder.DropTable(
                "ClientProperties",
                "IdentityConfiguration");

            migrationBuilder.DropTable(
                "ClientRedirectUris",
                "IdentityConfiguration");

            migrationBuilder.DropTable(
                "ClientScopes",
                "IdentityConfiguration");

            migrationBuilder.DropTable(
                "ClientSecrets",
                "IdentityConfiguration");

            migrationBuilder.DropTable(
                "IdentityClaims",
                "IdentityConfiguration");

            migrationBuilder.DropTable(
                "IdentityProperties",
                "IdentityConfiguration");

            migrationBuilder.DropTable(
                "ApiScopes",
                "IdentityConfiguration");

            migrationBuilder.DropTable(
                "Clients",
                "IdentityConfiguration");

            migrationBuilder.DropTable(
                "IdentityResources",
                "IdentityConfiguration");

            migrationBuilder.DropTable(
                "ApiResources",
                "IdentityConfiguration");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                "IdentityConfiguration");

            migrationBuilder.CreateTable(
                "ApiResources",
                schema: "IdentityConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(),
                    Name = table.Column<string>(maxLength: 200),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Created = table.Column<DateTime>(),
                    Updated = table.Column<DateTime>(nullable: true),
                    LastAccessed = table.Column<DateTime>(nullable: true),
                    NonEditable = table.Column<bool>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                "Clients",
                schema: "IdentityConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(),
                    ClientId = table.Column<string>(maxLength: 200),
                    ProtocolType = table.Column<string>(maxLength: 200),
                    RequireClientSecret = table.Column<bool>(),
                    ClientName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    ClientUri = table.Column<string>(maxLength: 2000, nullable: true),
                    LogoUri = table.Column<string>(maxLength: 2000, nullable: true),
                    RequireConsent = table.Column<bool>(),
                    AllowRememberConsent = table.Column<bool>(),
                    AlwaysIncludeUserClaimsInIdToken = table.Column<bool>(),
                    RequirePkce = table.Column<bool>(),
                    AllowPlainTextPkce = table.Column<bool>(),
                    AllowAccessTokensViaBrowser = table.Column<bool>(),
                    FrontChannelLogoutUri = table.Column<string>(maxLength: 2000, nullable: true),
                    FrontChannelLogoutSessionRequired = table.Column<bool>(),
                    BackChannelLogoutUri = table.Column<string>(maxLength: 2000, nullable: true),
                    BackChannelLogoutSessionRequired = table.Column<bool>(),
                    AllowOfflineAccess = table.Column<bool>(),
                    IdentityTokenLifetime = table.Column<int>(),
                    AccessTokenLifetime = table.Column<int>(),
                    AuthorizationCodeLifetime = table.Column<int>(),
                    ConsentLifetime = table.Column<int>(nullable: true),
                    AbsoluteRefreshTokenLifetime = table.Column<int>(),
                    SlidingRefreshTokenLifetime = table.Column<int>(),
                    RefreshTokenUsage = table.Column<int>(),
                    UpdateAccessTokenClaimsOnRefresh = table.Column<bool>(),
                    RefreshTokenExpiration = table.Column<int>(),
                    AccessTokenType = table.Column<int>(),
                    EnableLocalLogin = table.Column<bool>(),
                    IncludeJwtId = table.Column<bool>(),
                    AlwaysSendClientClaims = table.Column<bool>(),
                    ClientClaimsPrefix = table.Column<string>(maxLength: 200, nullable: true),
                    PairWiseSubjectSalt = table.Column<string>(maxLength: 200, nullable: true),
                    Created = table.Column<DateTime>(),
                    Updated = table.Column<DateTime>(nullable: true),
                    LastAccessed = table.Column<DateTime>(nullable: true),
                    UserSsoLifetime = table.Column<int>(nullable: true),
                    UserCodeType = table.Column<string>(maxLength: 100, nullable: true),
                    DeviceCodeLifetime = table.Column<int>(),
                    NonEditable = table.Column<bool>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                "IdentityResources",
                schema: "IdentityConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enabled = table.Column<bool>(),
                    Name = table.Column<string>(maxLength: 200),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Required = table.Column<bool>(),
                    Emphasize = table.Column<bool>(),
                    ShowInDiscoveryDocument = table.Column<bool>(),
                    Created = table.Column<DateTime>(),
                    Updated = table.Column<DateTime>(nullable: true),
                    NonEditable = table.Column<bool>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityResources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                "ApiClaims",
                schema: "IdentityConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(maxLength: 200),
                    ApiResourceId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_ApiClaims_ApiResources_ApiResourceId",
                        x => x.ApiResourceId,
                        principalSchema: "IdentityConfiguration",
                        principalTable: "ApiResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ApiProperties",
                schema: "IdentityConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(maxLength: 250),
                    Value = table.Column<string>(maxLength: 2000),
                    ApiResourceId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiProperties", x => x.Id);
                    table.ForeignKey(
                        "FK_ApiProperties_ApiResources_ApiResourceId",
                        x => x.ApiResourceId,
                        principalSchema: "IdentityConfiguration",
                        principalTable: "ApiResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ApiScopes",
                schema: "IdentityConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200),
                    DisplayName = table.Column<string>(maxLength: 200, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Required = table.Column<bool>(),
                    Emphasize = table.Column<bool>(),
                    ShowInDiscoveryDocument = table.Column<bool>(),
                    ApiResourceId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiScopes", x => x.Id);
                    table.ForeignKey(
                        "FK_ApiScopes_ApiResources_ApiResourceId",
                        x => x.ApiResourceId,
                        principalSchema: "IdentityConfiguration",
                        principalTable: "ApiResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ApiSecrets",
                schema: "IdentityConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Value = table.Column<string>(maxLength: 4000),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Type = table.Column<string>(maxLength: 250),
                    Created = table.Column<DateTime>(),
                    ApiResourceId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiSecrets", x => x.Id);
                    table.ForeignKey(
                        "FK_ApiSecrets_ApiResources_ApiResourceId",
                        x => x.ApiResourceId,
                        principalSchema: "IdentityConfiguration",
                        principalTable: "ApiResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClientClaims",
                schema: "IdentityConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(maxLength: 250),
                    Value = table.Column<string>(maxLength: 250),
                    ClientId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_ClientClaims_Clients_ClientId",
                        x => x.ClientId,
                        principalSchema: "IdentityConfiguration",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClientCorsOrigins",
                schema: "IdentityConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origin = table.Column<string>(maxLength: 150),
                    ClientId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCorsOrigins", x => x.Id);
                    table.ForeignKey(
                        "FK_ClientCorsOrigins_Clients_ClientId",
                        x => x.ClientId,
                        principalSchema: "IdentityConfiguration",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClientGrantTypes",
                schema: "IdentityConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrantType = table.Column<string>(maxLength: 250),
                    ClientId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientGrantTypes", x => x.Id);
                    table.ForeignKey(
                        "FK_ClientGrantTypes_Clients_ClientId",
                        x => x.ClientId,
                        principalSchema: "IdentityConfiguration",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClientIdPRestrictions",
                schema: "IdentityConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Provider = table.Column<string>(maxLength: 200),
                    ClientId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientIdPRestrictions", x => x.Id);
                    table.ForeignKey(
                        "FK_ClientIdPRestrictions_Clients_ClientId",
                        x => x.ClientId,
                        principalSchema: "IdentityConfiguration",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClientPostLogoutRedirectUris",
                schema: "IdentityConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostLogoutRedirectUri = table.Column<string>(maxLength: 2000),
                    ClientId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPostLogoutRedirectUris", x => x.Id);
                    table.ForeignKey(
                        "FK_ClientPostLogoutRedirectUris_Clients_ClientId",
                        x => x.ClientId,
                        principalSchema: "IdentityConfiguration",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClientProperties",
                schema: "IdentityConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(maxLength: 250),
                    Value = table.Column<string>(maxLength: 2000),
                    ClientId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientProperties", x => x.Id);
                    table.ForeignKey(
                        "FK_ClientProperties_Clients_ClientId",
                        x => x.ClientId,
                        principalSchema: "IdentityConfiguration",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClientRedirectUris",
                schema: "IdentityConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RedirectUri = table.Column<string>(maxLength: 2000),
                    ClientId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientRedirectUris", x => x.Id);
                    table.ForeignKey(
                        "FK_ClientRedirectUris_Clients_ClientId",
                        x => x.ClientId,
                        principalSchema: "IdentityConfiguration",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClientScopes",
                schema: "IdentityConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Scope = table.Column<string>(maxLength: 200),
                    ClientId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientScopes", x => x.Id);
                    table.ForeignKey(
                        "FK_ClientScopes_Clients_ClientId",
                        x => x.ClientId,
                        principalSchema: "IdentityConfiguration",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ClientSecrets",
                schema: "IdentityConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    Value = table.Column<string>(maxLength: 4000),
                    Expiration = table.Column<DateTime>(nullable: true),
                    Type = table.Column<string>(maxLength: 250),
                    Created = table.Column<DateTime>(),
                    ClientId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientSecrets", x => x.Id);
                    table.ForeignKey(
                        "FK_ClientSecrets_Clients_ClientId",
                        x => x.ClientId,
                        principalSchema: "IdentityConfiguration",
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityClaims",
                schema: "IdentityConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(maxLength: 200),
                    IdentityResourceId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_IdentityClaims_IdentityResources_IdentityResourceId",
                        x => x.IdentityResourceId,
                        principalSchema: "IdentityConfiguration",
                        principalTable: "IdentityResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "IdentityProperties",
                schema: "IdentityConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(maxLength: 250),
                    Value = table.Column<string>(maxLength: 2000),
                    IdentityResourceId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityProperties", x => x.Id);
                    table.ForeignKey(
                        "FK_IdentityProperties_IdentityResources_IdentityResourceId",
                        x => x.IdentityResourceId,
                        principalSchema: "IdentityConfiguration",
                        principalTable: "IdentityResources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ApiScopeClaims",
                schema: "IdentityConfiguration",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(maxLength: 200),
                    ApiScopeId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiScopeClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_ApiScopeClaims_ApiScopes_ApiScopeId",
                        x => x.ApiScopeId,
                        principalSchema: "IdentityConfiguration",
                        principalTable: "ApiScopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_ApiClaims_ApiResourceId",
                schema: "IdentityConfiguration",
                table: "ApiClaims",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                "IX_ApiProperties_ApiResourceId",
                schema: "IdentityConfiguration",
                table: "ApiProperties",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                "IX_ApiResources_Name",
                schema: "IdentityConfiguration",
                table: "ApiResources",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_ApiScopeClaims_ApiScopeId",
                schema: "IdentityConfiguration",
                table: "ApiScopeClaims",
                column: "ApiScopeId");

            migrationBuilder.CreateIndex(
                "IX_ApiScopes_ApiResourceId",
                schema: "IdentityConfiguration",
                table: "ApiScopes",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                "IX_ApiScopes_Name",
                schema: "IdentityConfiguration",
                table: "ApiScopes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_ApiSecrets_ApiResourceId",
                schema: "IdentityConfiguration",
                table: "ApiSecrets",
                column: "ApiResourceId");

            migrationBuilder.CreateIndex(
                "IX_ClientClaims_ClientId",
                schema: "IdentityConfiguration",
                table: "ClientClaims",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                "IX_ClientCorsOrigins_ClientId",
                schema: "IdentityConfiguration",
                table: "ClientCorsOrigins",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                "IX_ClientGrantTypes_ClientId",
                schema: "IdentityConfiguration",
                table: "ClientGrantTypes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                "IX_ClientIdPRestrictions_ClientId",
                schema: "IdentityConfiguration",
                table: "ClientIdPRestrictions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                "IX_ClientPostLogoutRedirectUris_ClientId",
                schema: "IdentityConfiguration",
                table: "ClientPostLogoutRedirectUris",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                "IX_ClientProperties_ClientId",
                schema: "IdentityConfiguration",
                table: "ClientProperties",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                "IX_ClientRedirectUris_ClientId",
                schema: "IdentityConfiguration",
                table: "ClientRedirectUris",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                "IX_Clients_ClientId",
                schema: "IdentityConfiguration",
                table: "Clients",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_ClientScopes_ClientId",
                schema: "IdentityConfiguration",
                table: "ClientScopes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                "IX_ClientSecrets_ClientId",
                schema: "IdentityConfiguration",
                table: "ClientSecrets",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                "IX_IdentityClaims_IdentityResourceId",
                schema: "IdentityConfiguration",
                table: "IdentityClaims",
                column: "IdentityResourceId");

            migrationBuilder.CreateIndex(
                "IX_IdentityProperties_IdentityResourceId",
                schema: "IdentityConfiguration",
                table: "IdentityProperties",
                column: "IdentityResourceId");

            migrationBuilder.CreateIndex(
                "IX_IdentityResources_Name",
                schema: "IdentityConfiguration",
                table: "IdentityResources",
                column: "Name",
                unique: true);
        }
    }
}