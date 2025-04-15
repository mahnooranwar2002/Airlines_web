using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airlines_Booking.Migrations
{
    /// <inheritdoc />
    public partial class myflights_plans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "busneiss_seats",
                table: "tbl_plan");

            migrationBuilder.DropColumn(
                name: "economy_seats",
                table: "tbl_plan");

            migrationBuilder.DropColumn(
                name: "seat_avaiable",
                table: "tbl_plan");

            migrationBuilder.AddColumn<int>(
                name: "busneiss_seats",
                table: "tbl_flightsmanagement",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "economy_seats",
                table: "tbl_flightsmanagement",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "seat_avaiable",
                table: "tbl_flightsmanagement",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "busneiss_seats",
                table: "tbl_flightsmanagement");

            migrationBuilder.DropColumn(
                name: "economy_seats",
                table: "tbl_flightsmanagement");

            migrationBuilder.DropColumn(
                name: "seat_avaiable",
                table: "tbl_flightsmanagement");

            migrationBuilder.AddColumn<int>(
                name: "busneiss_seats",
                table: "tbl_plan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "economy_seats",
                table: "tbl_plan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "seat_avaiable",
                table: "tbl_plan",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
