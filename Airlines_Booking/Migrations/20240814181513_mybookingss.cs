using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airlines_Booking.Migrations
{
    /// <inheritdoc />
    public partial class mybookingss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "city_id",
                table: "tbl_airlineticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_airlineticket_tbl_city_city_id",
                table: "tbl_airlineticket");

            migrationBuilder.DropIndex(
                name: "IX_tbl_airlineticket_city_id",
                table: "tbl_airlineticket");

            migrationBuilder.DropColumn(
                name: "city_id",
                table: "tbl_airlineticket");
        }
    }
}
