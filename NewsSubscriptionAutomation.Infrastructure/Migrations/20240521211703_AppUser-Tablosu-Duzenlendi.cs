using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsSubscriptionAutomation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AppUserTablosuDuzenlendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubscriptionType",
                table: "AppUser");

            migrationBuilder.CreateTable(
                name: "NewsPapers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSubscriber = table.Column<bool>(type: "bit", nullable: false),
                    SubscriptionType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsPapers", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserNewsPaper");

            migrationBuilder.DropTable(
                name: "NewsPapers");

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionType",
                table: "AppUser",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
