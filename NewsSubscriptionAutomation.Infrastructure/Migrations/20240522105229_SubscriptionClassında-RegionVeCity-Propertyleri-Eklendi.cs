using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsSubscriptionAutomation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SubscriptionClassındaRegionVeCityPropertyleriEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "City",
                table: "Subscriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Region",
                table: "Subscriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Subscriptions");
        }
    }
}
