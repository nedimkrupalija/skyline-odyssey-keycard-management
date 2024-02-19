using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace skyline_odyssey_keycard_management.Migrations
{
    /// <inheritdoc />
    public partial class migr8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsageHistory_Keycard_KeycardId",
                table: "UsageHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_UsageHistory_User_UserId",
                table: "UsageHistory");

            migrationBuilder.DropIndex(
                name: "IX_UsageHistory_KeycardId",
                table: "UsageHistory");

            migrationBuilder.DropIndex(
                name: "IX_UsageHistory_UserId",
                table: "UsageHistory");

            migrationBuilder.DropColumn(
                name: "KeycardId",
                table: "UsageHistory");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UsageHistory");

            migrationBuilder.AddColumn<int>(
                name: "UsageHistoryId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_UsageHistoryId",
                table: "User",
                column: "UsageHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UsageHistory_CardId",
                table: "UsageHistory",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsageHistory_Keycard_CardId",
                table: "UsageHistory",
                column: "CardId",
                principalTable: "Keycard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UsageHistory_UsageHistoryId",
                table: "User",
                column: "UsageHistoryId",
                principalTable: "UsageHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsageHistory_Keycard_CardId",
                table: "UsageHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UsageHistory_UsageHistoryId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UsageHistoryId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_UsageHistory_CardId",
                table: "UsageHistory");

            migrationBuilder.DropColumn(
                name: "UsageHistoryId",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "KeycardId",
                table: "UsageHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UsageHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UsageHistory_KeycardId",
                table: "UsageHistory",
                column: "KeycardId");

            migrationBuilder.CreateIndex(
                name: "IX_UsageHistory_UserId",
                table: "UsageHistory",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsageHistory_Keycard_KeycardId",
                table: "UsageHistory",
                column: "KeycardId",
                principalTable: "Keycard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsageHistory_User_UserId",
                table: "UsageHistory",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
