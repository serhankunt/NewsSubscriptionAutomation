using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsSubscriptionAutomation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mg3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserNewsPaper");

            migrationBuilder.CreateTable(
                name: "AppUserNewsPapers",
                columns: table => new
                {
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NewsPaperId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserNewsPapers", x => new { x.AppUserId, x.NewsPaperId });
                    table.ForeignKey(
                        name: "FK_AppUserNewsPapers_AppUser_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserNewsPapers_NewsPapers_NewsPaperId",
                        column: x => x.NewsPaperId,
                        principalTable: "NewsPapers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserNewsPapers_NewsPaperId",
                table: "AppUserNewsPapers",
                column: "NewsPaperId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserNewsPapers");

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
