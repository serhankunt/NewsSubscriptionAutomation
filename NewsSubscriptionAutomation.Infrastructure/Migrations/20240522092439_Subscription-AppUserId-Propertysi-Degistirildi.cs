using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsSubscriptionAutomation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SubscriptionAppUserIdPropertysiDegistirildi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_AppUser_UserId",
                table: "Subscriptions");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Subscriptions",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Subscriptions_UserId",
                table: "Subscriptions",
                newName: "IX_Subscriptions_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_AppUser_AppUserId",
                table: "Subscriptions",
                column: "AppUserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_AppUser_AppUserId",
                table: "Subscriptions");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Subscriptions",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Subscriptions_AppUserId",
                table: "Subscriptions",
                newName: "IX_Subscriptions_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_AppUser_UserId",
                table: "Subscriptions",
                column: "UserId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
