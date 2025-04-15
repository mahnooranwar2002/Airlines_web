using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airlines_Booking.Migrations
{
    /// <inheritdoc />
    public partial class airlinesflights : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_flightsmanagement_tbl_country_travel_to",
                table: "tbl_flightsmanagement");

            migrationBuilder.DropIndex(
                name: "IX_tbl_flightsmanagement_travel_to",
                table: "tbl_flightsmanagement");

            migrationBuilder.AlterColumn<string>(
                name: "travel_to",
                table: "tbl_flightsmanagement",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_flightsmanagement_travel_from",
                table: "tbl_flightsmanagement",
                column: "travel_from");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_flightsmanagement_tbl_country_travel_from",
                table: "tbl_flightsmanagement",
                column: "travel_from",
                principalTable: "tbl_country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_flightsmanagement_tbl_country_travel_from",
                table: "tbl_flightsmanagement");

            migrationBuilder.DropIndex(
                name: "IX_tbl_flightsmanagement_travel_from",
                table: "tbl_flightsmanagement");

            migrationBuilder.AlterColumn<int>(
                name: "travel_to",
                table: "tbl_flightsmanagement",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_flightsmanagement_travel_to",
                table: "tbl_flightsmanagement",
                column: "travel_to");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_flightsmanagement_tbl_country_travel_to",
                table: "tbl_flightsmanagement",
                column: "travel_to",
                principalTable: "tbl_country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
