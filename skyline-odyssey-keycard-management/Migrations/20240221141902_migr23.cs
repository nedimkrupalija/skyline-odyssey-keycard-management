using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace skyline_odyssey_keycard_management.Migrations
{
    /// <inheritdoc />
    public partial class migr23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOnline",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOnline",
                table: "User");
        }
    }
}
