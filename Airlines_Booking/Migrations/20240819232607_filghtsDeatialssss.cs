using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airlines_Booking.Migrations
{
    /// <inheritdoc />
    public partial class filghtsDeatialssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_airlineticket_tbl_city_city_id",
                table: "tbl_airlineticket");

            migrationBuilder.DropIndex(
                name: "IX_tbl_airlineticket_city_id",
                table: "tbl_airlineticket");

            migrationBuilder.AddColumn<string>(
                name: "cities",
                table: "tbl_flightsmanagement",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "tbl_airlineticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Country_id",
                table: "tbl_airlineticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "city",
                table: "tbl_airlineticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "cityid",
                table: "tbl_airlineticket",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_airlineticket_cityid",
                table: "tbl_airlineticket",
                column: "cityid");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_airlineticket_tbl_city_cityid",
                table: "tbl_airlineticket",
                column: "cityid",
                principalTable: "tbl_city",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_airlineticket_tbl_city_cityid",
                table: "tbl_airlineticket");

            migrationBuilder.DropIndex(
                name: "IX_tbl_airlineticket_cityid",
                table: "tbl_airlineticket");

            migrationBuilder.DropColumn(
                name: "cities",
                table: "tbl_flightsmanagement");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "tbl_airlineticket");

            migrationBuilder.DropColumn(
                name: "Country_id",
                table: "tbl_airlineticket");

            migrationBuilder.DropColumn(
                name: "city",
                table: "tbl_airlineticket");

            migrationBuilder.DropColumn(
                name: "cityid",
                table: "tbl_airlineticket");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_airlineticket_city_id",
                table: "tbl_airlineticket",
                column: "city_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_airlineticket_tbl_city_city_id",
                table: "tbl_airlineticket",
                column: "city_id",
                principalTable: "tbl_city",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
