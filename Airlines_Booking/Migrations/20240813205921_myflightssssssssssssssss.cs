using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airlines_Booking.Migrations
{
    /// <inheritdoc />
    public partial class myflightssssssssssssssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_flightsmanagement_tbl_arrivalecountry_travel_to",
                table: "tbl_flightsmanagement");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_flightsmanagement_tbl_country_travel_from",
                table: "tbl_flightsmanagement");

            migrationBuilder.DropTable(
                name: "tbl_arrivalecountry");

            migrationBuilder.DropIndex(
                name: "IX_tbl_flightsmanagement_travel_from",
                table: "tbl_flightsmanagement");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_flightsmanagement_tbl_country_travel_to",
                table: "tbl_flightsmanagement",
                column: "travel_to",
                principalTable: "tbl_country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_flightsmanagement_tbl_country_travel_to",
                table: "tbl_flightsmanagement");

            migrationBuilder.CreateTable(
                name: "tbl_arrivalecountry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_arrivalecountry", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_flightsmanagement_travel_from",
                table: "tbl_flightsmanagement",
                column: "travel_from");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_flightsmanagement_tbl_arrivalecountry_travel_to",
                table: "tbl_flightsmanagement",
                column: "travel_to",
                principalTable: "tbl_arrivalecountry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_flightsmanagement_tbl_country_travel_from",
                table: "tbl_flightsmanagement",
                column: "travel_from",
                principalTable: "tbl_country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
