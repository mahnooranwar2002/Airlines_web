using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airlines_Booking.Migrations
{
    /// <inheritdoc />
    public partial class final_flights : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "baggage",
                table: "tbl_airlineticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "seat_num",
                table: "tbl_airlineticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "baggage",
                table: "tbl_airlineticket");

            migrationBuilder.DropColumn(
                name: "seat_num",
                table: "tbl_airlineticket");
        }
    }
}
