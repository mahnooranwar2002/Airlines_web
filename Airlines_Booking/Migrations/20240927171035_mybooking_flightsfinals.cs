using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airlines_Booking.Migrations
{
    /// <inheritdoc />
    public partial class mybooking_flightsfinals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "flight_name",
                table: "tbl_airlineticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "gate_no",
                table: "tbl_airlineticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "flight_name",
                table: "tbl_airlineticket");

            migrationBuilder.DropColumn(
                name: "gate_no",
                table: "tbl_airlineticket");
        }
    }
}
