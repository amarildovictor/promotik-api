using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromoTik.Data.Migrations
{
    /// <inheritdoc />
    public partial class firstScript : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "GENERAL_CONFIGURATION",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GENERAL_CONFIGURATION", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PUBLISH_CHAT_MESSAGE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValueWithouDiscount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Value = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Coupon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AditionalMessage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PUBLISH_CHAT_MESSAGE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PUBLISHING_APP",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    EndpointUrl = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PUBLISHING_APP", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WAREHOUSE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAREHOUSE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LINE_EXECUTION",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublishChatMessageID = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExecutionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LINE_EXECUTION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LINE_EXECUTION_PUBLISH_CHAT_MESSAGE_PublishChatMessageID",
                        column: x => x.PublishChatMessageID,
                        principalTable: "PUBLISH_CHAT_MESSAGE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PUBLISHING_CHANNEL",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Channel_ID = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PublishingAppID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PUBLISHING_CHANNEL", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PUBLISHING_CHANNEL_PUBLISHING_APP_PublishingAppID",
                        column: x => x.PublishingAppID,
                        principalTable: "PUBLISHING_APP",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PUBLISHCHATMESSAGE_WAREHOUSE",
                columns: table => new
                {
                    PublishChatMessageID = table.Column<int>(type: "int", nullable: false),
                    WarehouseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PUBLISHCHATMESSAGE_WAREHOUSE", x => new { x.PublishChatMessageID, x.WarehouseID });
                    table.ForeignKey(
                        name: "FK_PUBLISHCHATMESSAGE_WAREHOUSE_PUBLISH_CHAT_MESSAGE_PublishChatMessageID",
                        column: x => x.PublishChatMessageID,
                        principalTable: "PUBLISH_CHAT_MESSAGE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PUBLISHCHATMESSAGE_WAREHOUSE_WAREHOUSE_WarehouseID",
                        column: x => x.WarehouseID,
                        principalTable: "WAREHOUSE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SCHEDULED_LINE_EXECUTION",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduledDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LineExecutionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHEDULED_LINE_EXECUTION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SCHEDULED_LINE_EXECUTION_LINE_EXECUTION_LineExecutionID",
                        column: x => x.LineExecutionID,
                        principalTable: "LINE_EXECUTION",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PUBLISHCHATMESSAGE_PUBLISHINGCHANNEL",
                columns: table => new
                {
                    PublishChatMessageID = table.Column<int>(type: "int", nullable: false),
                    PublishingChannelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PUBLISHCHATMESSAGE_PUBLISHINGCHANNEL", x => new { x.PublishChatMessageID, x.PublishingChannelID });
                    table.ForeignKey(
                        name: "FK_PUBLISHCHATMESSAGE_PUBLISHINGCHANNEL_PUBLISHING_CHANNEL_PublishingChannelID",
                        column: x => x.PublishingChannelID,
                        principalTable: "PUBLISHING_CHANNEL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PUBLISHCHATMESSAGE_PUBLISHINGCHANNEL_PUBLISH_CHAT_MESSAGE_PublishChatMessageID",
                        column: x => x.PublishChatMessageID,
                        principalTable: "PUBLISH_CHAT_MESSAGE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PUBLISHING_CHANNEL_PARAMETERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Parameter = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishingChannelID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PUBLISHING_CHANNEL_PARAMETERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PUBLISHING_CHANNEL_PARAMETERS_PUBLISHING_CHANNEL_PublishingChannelID",
                        column: x => x.PublishingChannelID,
                        principalTable: "PUBLISHING_CHANNEL",
                        principalColumn: "ID");
                });

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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LINE_EXECUTION_PublishChatMessageID",
                table: "LINE_EXECUTION",
                column: "PublishChatMessageID");

            migrationBuilder.CreateIndex(
                name: "IX_PUBLISHCHATMESSAGE_PUBLISHINGCHANNEL_PublishingChannelID",
                table: "PUBLISHCHATMESSAGE_PUBLISHINGCHANNEL",
                column: "PublishingChannelID");

            migrationBuilder.CreateIndex(
                name: "IX_PUBLISHCHATMESSAGE_WAREHOUSE_WarehouseID",
                table: "PUBLISHCHATMESSAGE_WAREHOUSE",
                column: "WarehouseID");

            migrationBuilder.CreateIndex(
                name: "IX_PUBLISHING_CHANNEL_PublishingAppID",
                table: "PUBLISHING_CHANNEL",
                column: "PublishingAppID");

            migrationBuilder.CreateIndex(
                name: "IX_PUBLISHING_CHANNEL_PARAMETERS_PublishingChannelID",
                table: "PUBLISHING_CHANNEL_PARAMETERS",
                column: "PublishingChannelID");

            migrationBuilder.CreateIndex(
                name: "IX_SCHEDULED_LINE_EXECUTION_LineExecutionID",
                table: "SCHEDULED_LINE_EXECUTION",
                column: "LineExecutionID");
        }

        /// <inheritdoc />
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
                name: "GENERAL_CONFIGURATION");

            migrationBuilder.DropTable(
                name: "PUBLISHCHATMESSAGE_PUBLISHINGCHANNEL");

            migrationBuilder.DropTable(
                name: "PUBLISHCHATMESSAGE_WAREHOUSE");

            migrationBuilder.DropTable(
                name: "PUBLISHING_CHANNEL_PARAMETERS");

            migrationBuilder.DropTable(
                name: "SCHEDULED_LINE_EXECUTION");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "WAREHOUSE");

            migrationBuilder.DropTable(
                name: "PUBLISHING_CHANNEL");

            migrationBuilder.DropTable(
                name: "LINE_EXECUTION");

            migrationBuilder.DropTable(
                name: "PUBLISHING_APP");

            migrationBuilder.DropTable(
                name: "PUBLISH_CHAT_MESSAGE");
        }
    }
}
