using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace skyline_odyssey_keycard_management.Migrations
{
    /// <inheritdoc />
    public partial class migr19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Keycard_User_UserId",
                table: "Keycard");

            migrationBuilder.DropIndex(
                name: "IX_Keycard_UserId",
                table: "Keycard");

            migrationBuilder.DropColumn(
                name: "Keycard",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Keycard");

            migrationBuilder.AddColumn<int>(
                name: "KeycardId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_KeycardId",
                table: "User",
                column: "KeycardId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Keycard_KeycardId",
                table: "User",
                column: "KeycardId",
                principalTable: "Keycard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Keycard_KeycardId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_KeycardId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "KeycardId",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Keycard",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Keycard",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Keycard_UserId",
                table: "Keycard",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Keycard_User_UserId",
                table: "Keycard",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
