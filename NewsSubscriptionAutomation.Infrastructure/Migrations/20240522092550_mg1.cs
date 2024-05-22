using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsSubscriptionAutomation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserNewsPaper");

            migrationBuilder.AddColumn<int>(
                name: "NewsPaperId",
                table: "AppUser",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_NewsPaperId",
                table: "AppUser",
                column: "NewsPaperId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_NewsPapers_NewsPaperId",
                table: "AppUser",
                column: "NewsPaperId",
                principalTable: "NewsPapers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_NewsPapers_NewsPaperId",
                table: "AppUser");

            migrationBuilder.DropIndex(
                name: "IX_AppUser_NewsPaperId",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "NewsPaperId",
                table: "AppUser");

            migrationBuilder.CreateTable(
                name: "AppUserNewsPaper",
                columns: table => new
                {
                    NewsPapersId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserNewsPaper", x => new { x.NewsPapersId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_AppUserNewsPaper_AppUser_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserNewsPaper_NewsPapers_NewsPapersId",
                        column: x => x.NewsPapersId,
                        principalTable: "NewsPapers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserNewsPaper_UsersId",
                table: "AppUserNewsPaper",
                column: "UsersId");
        }
    }
}
