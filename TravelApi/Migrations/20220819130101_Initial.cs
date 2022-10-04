using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelApi.Solution.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destination",
                columns: table => new
                {
                    DestinationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "varchar(15) CHARACTER SET utf8mb4", maxLength: 15, nullable: false),
                    Country = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    City = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    DestinationName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Review = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destination", x => x.DestinationId);
                });

            migrationBuilder.InsertData(
                table: "Destination",
                columns: new[] { "DestinationId", "City", "Country", "DestinationName", "Review", "Username" },
                values: new object[] { 1, "Lagos", "Nigeria", "EmmanuelPark", "Emmanurl park is one of the best restaurants in nigeria", "Danny" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Destination");
        }
    }
}
