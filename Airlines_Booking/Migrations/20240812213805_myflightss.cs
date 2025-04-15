using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airlines_Booking.Migrations
{
    /// <inheritdoc />
    public partial class myflightss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_flights_tbl_plan_Plane",
                table: "tbl_flights");

            migrationBuilder.RenameColumn(
                name: "Plane",
                table: "tbl_flights",
                newName: "Plane_id");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_flights_Plane",
                table: "tbl_flights",
                newName: "IX_tbl_flights_Plane_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_flights_tbl_plan_Plane_id",
                table: "tbl_flights",
                column: "Plane_id",
                principalTable: "tbl_plan",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_flights_tbl_plan_Plane_id",
                table: "tbl_flights");

            migrationBuilder.RenameColumn(
                name: "Plane_id",
                table: "tbl_flights",
                newName: "Plane");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_flights_Plane_id",
                table: "tbl_flights",
                newName: "IX_tbl_flights_Plane");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_flights_tbl_plan_Plane",
                table: "tbl_flights",
                column: "Plane",
                principalTable: "tbl_plan",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
