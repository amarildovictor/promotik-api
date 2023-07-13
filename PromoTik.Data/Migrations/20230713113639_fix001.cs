using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromoTik.Data.Migrations
{
    /// <inheritdoc />
    public partial class fix001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_LINE_EXECUTION_PublishChatMessageID",
                table: "LINE_EXECUTION",
                column: "PublishChatMessageID");

            migrationBuilder.CreateIndex(
                name: "IX_SCHEDULED_LINE_EXECUTION_LineExecutionID",
                table: "SCHEDULED_LINE_EXECUTION",
                column: "LineExecutionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GENERAL_CONFIGURATION");

            migrationBuilder.DropTable(
                name: "SCHEDULED_LINE_EXECUTION");

            migrationBuilder.DropTable(
                name: "LINE_EXECUTION");
        }
    }
}
