using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airlines_Booking.Migrations
{
    /// <inheritdoc />
    public partial class myflightmanagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_flights_tbl_country_travel_to",
                table: "tbl_flights");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_flights_tbl_plan_Plane_id",
                table: "tbl_flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_flights",
                table: "tbl_flights");

            migrationBuilder.RenameTable(
                name: "tbl_flights",
                newName: "tbl_flightsmanagement");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_flights_travel_to",
                table: "tbl_flightsmanagement",
                newName: "IX_tbl_flightsmanagement_travel_to");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_flights_Plane_id",
                table: "tbl_flightsmanagement",
                newName: "IX_tbl_flightsmanagement_Plane_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_flightsmanagement",
                table: "tbl_flightsmanagement",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_flightsmanagement_tbl_country_travel_to",
                table: "tbl_flightsmanagement",
                column: "travel_to",
                principalTable: "tbl_country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_flightsmanagement_tbl_plan_Plane_id",
                table: "tbl_flightsmanagement",
                column: "Plane_id",
                principalTable: "tbl_plan",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_flightsmanagement_tbl_country_travel_to",
                table: "tbl_flightsmanagement");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_flightsmanagement_tbl_plan_Plane_id",
                table: "tbl_flightsmanagement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_flightsmanagement",
                table: "tbl_flightsmanagement");

            migrationBuilder.RenameTable(
                name: "tbl_flightsmanagement",
                newName: "tbl_flights");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_flightsmanagement_travel_to",
                table: "tbl_flights",
                newName: "IX_tbl_flights_travel_to");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_flightsmanagement_Plane_id",
                table: "tbl_flights",
                newName: "IX_tbl_flights_Plane_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_flights",
                table: "tbl_flights",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_flights_tbl_country_travel_to",
                table: "tbl_flights",
                column: "travel_to",
                principalTable: "tbl_country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_flights_tbl_plan_Plane_id",
                table: "tbl_flights",
                column: "Plane_id",
                principalTable: "tbl_plan",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
