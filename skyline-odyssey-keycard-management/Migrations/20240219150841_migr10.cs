using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace skyline_odyssey_keycard_management.Migrations
{
    /// <inheritdoc />
    public partial class migr10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Keycard_User_UserId",
                table: "Keycard");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_User_UserId",
                table: "Role");

            migrationBuilder.DropForeignKey(
                name: "FK_UsageHistory_Keycard_CardId",
                table: "UsageHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Keycard_CardId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UsageHistory_UsageHistoryId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_CardId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UsageHistoryId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsageHistory",
                table: "UsageHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Role_UserId",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Keycard",
                table: "Keycard");

            migrationBuilder.DropIndex(
                name: "IX_Keycard_UserId",
                table: "Keycard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccessPoint",
                table: "AccessPoint");

            migrationBuilder.DropColumn(
                name: "UsageHistoryId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Role");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "UsageHistory",
                newName: "UsageHistories");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "Keycard",
                newName: "Keycards");

            migrationBuilder.RenameTable(
                name: "AccessPoint",
                newName: "AccessPoints");

            migrationBuilder.RenameIndex(
                name: "IX_User_RoleId",
                table: "Users",
                newName: "IX_Users_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UsageHistory_CardId",
                table: "UsageHistories",
                newName: "IX_UsageHistories_CardId");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UsageHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsageHistories",
                table: "UsageHistories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Keycards",
                table: "Keycards",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccessPoints",
                table: "AccessPoints",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsageHistories_UserId",
                table: "UsageHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Keycards_UserId",
                table: "Keycards",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Keycards_Users_UserId",
                table: "Keycards",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsageHistories_Keycards_CardId",
                table: "UsageHistories",
                column: "CardId",
                principalTable: "Keycards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsageHistories_Users_UserId",
                table: "UsageHistories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Keycards_Users_UserId",
                table: "Keycards");

            migrationBuilder.DropForeignKey(
                name: "FK_UsageHistories_Keycards_CardId",
                table: "UsageHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_UsageHistories_Users_UserId",
                table: "UsageHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsageHistories",
                table: "UsageHistories");

            migrationBuilder.DropIndex(
                name: "IX_UsageHistories_UserId",
                table: "UsageHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Keycards",
                table: "Keycards");

            migrationBuilder.DropIndex(
                name: "IX_Keycards_UserId",
                table: "Keycards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccessPoints",
                table: "AccessPoints");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UsageHistories");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "UsageHistories",
                newName: "UsageHistory");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "Keycards",
                newName: "Keycard");

            migrationBuilder.RenameTable(
                name: "AccessPoints",
                newName: "AccessPoint");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleId",
                table: "User",
                newName: "IX_User_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UsageHistories_CardId",
                table: "UsageHistory",
                newName: "IX_UsageHistory_CardId");

            migrationBuilder.AddColumn<int>(
                name: "UsageHistoryId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Role",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsageHistory",
                table: "UsageHistory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Keycard",
                table: "Keycard",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccessPoint",
                table: "AccessPoint",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_CardId",
                table: "User",
                column: "CardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UsageHistoryId",
                table: "User",
                column: "UsageHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_UserId",
                table: "Role",
                column: "UserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Role_User_UserId",
                table: "Role",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsageHistory_Keycard_CardId",
                table: "UsageHistory",
                column: "CardId",
                principalTable: "Keycard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Keycard_CardId",
                table: "User",
                column: "CardId",
                principalTable: "Keycard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User",
                column: "RoleId",
                principalTable: "Role",
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
    }
}
