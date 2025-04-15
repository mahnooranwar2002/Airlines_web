using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airlines_Booking.Migrations
{
    /// <inheritdoc />
    public partial class cities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_flightsmanagement_city_city_id",
                table: "tbl_flightsmanagement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_city",
                table: "city");

            migrationBuilder.RenameTable(
                name: "city",
                newName: "tbl_city");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_city",
                table: "tbl_city",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_flightsmanagement_tbl_city_city_id",
                table: "tbl_flightsmanagement",
                column: "city_id",
                principalTable: "tbl_city",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_flightsmanagement_tbl_city_city_id",
                table: "tbl_flightsmanagement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_city",
                table: "tbl_city");

            migrationBuilder.RenameTable(
                name: "tbl_city",
                newName: "city");

            migrationBuilder.AddPrimaryKey(
                name: "PK_city",
                table: "city",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_flightsmanagement_city_city_id",
                table: "tbl_flightsmanagement",
                column: "city_id",
                principalTable: "city",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
