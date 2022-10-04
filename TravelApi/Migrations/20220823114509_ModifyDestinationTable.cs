using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelApi.Solution.Migrations
{
    public partial class ModifyDestinationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "OverallRating",
                table: "Destination",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OverallRating",
                table: "Destination");
        }
    }
}
