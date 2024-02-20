using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace skyline_odyssey_keycard_management.Migrations
{
    /// <inheritdoc />
    public partial class migr20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessPointId",
                table: "UsageHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsAssigned",
                table: "Keycard",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_UsageHistory_AccessPointId",
                table: "UsageHistory",
                column: "AccessPointId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsageHistory_AccessPoint_AccessPointId",
                table: "UsageHistory",
                column: "AccessPointId",
                principalTable: "AccessPoint",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsageHistory_AccessPoint_AccessPointId",
                table: "UsageHistory");

            migrationBuilder.DropIndex(
                name: "IX_UsageHistory_AccessPointId",
                table: "UsageHistory");

            migrationBuilder.DropColumn(
                name: "AccessPointId",
                table: "UsageHistory");

            migrationBuilder.DropColumn(
                name: "IsAssigned",
                table: "Keycard");
        }
    }
}
