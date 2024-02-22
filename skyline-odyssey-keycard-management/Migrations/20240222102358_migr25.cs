using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace skyline_odyssey_keycard_management.Migrations
{
    /// <inheritdoc />
    public partial class migr25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEntry",
                table: "UsageHistory");

            migrationBuilder.AddColumn<string>(
                name: "InOut",
                table: "UsageHistory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InOut",
                table: "UsageHistory");

            migrationBuilder.AddColumn<bool>(
                name: "IsEntry",
                table: "UsageHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
