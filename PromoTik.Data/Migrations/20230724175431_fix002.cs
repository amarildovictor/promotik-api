using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromoTik.Data.Migrations
{
    /// <inheritdoc />
    public partial class fix002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Country",
                table: "PUBLISHING_CHANNEL",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "PUBLISHING_CHANNEL");
        }
    }
}
