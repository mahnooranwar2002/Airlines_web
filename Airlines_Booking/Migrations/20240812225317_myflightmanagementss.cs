using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airlines_Booking.Migrations
{
    /// <inheritdoc />
    public partial class myflightmanagementss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "airline_date",
                table: "tbl_flightsmanagement",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "city_id",
                table: "tbl_flightsmanagement",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "duration",
                table: "tbl_flightsmanagement",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_flightsmanagement_city_id",
                table: "tbl_flightsmanagement",
                column: "city_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_flightsmanagement_city_city_id",
                table: "tbl_flightsmanagement",
                column: "city_id",
                principalTable: "city",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_flightsmanagement_city_city_id",
                table: "tbl_flightsmanagement");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropIndex(
                name: "IX_tbl_flightsmanagement_city_id",
                table: "tbl_flightsmanagement");

            migrationBuilder.DropColumn(
                name: "airline_date",
                table: "tbl_flightsmanagement");

            migrationBuilder.DropColumn(
                name: "city_id",
                table: "tbl_flightsmanagement");

            migrationBuilder.DropColumn(
                name: "duration",
                table: "tbl_flightsmanagement");
        }
    }
}
