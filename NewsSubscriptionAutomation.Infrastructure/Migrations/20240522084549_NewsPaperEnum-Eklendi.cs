using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsSubscriptionAutomation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewsPaperEnumEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSubscriber",
                table: "NewsPapers");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "NewsPapers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "NewsPapers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsSubscriber",
                table: "NewsPapers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
