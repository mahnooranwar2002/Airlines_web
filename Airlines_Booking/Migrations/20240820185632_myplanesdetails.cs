using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airlines_Booking.Migrations
{
    /// <inheritdoc />
    public partial class myplanesdetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "busneiss_seats",
                table: "tbl_plan");

            migrationBuilder.DropColumn(
                name: "economy_seats",
                table: "tbl_plan");
        }
    }
}
