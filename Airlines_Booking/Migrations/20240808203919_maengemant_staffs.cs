using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airlines_Booking.Migrations
{
    /// <inheritdoc />
    public partial class maengemant_staffs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "joining_date",
                table: "tbl_managementStaff");

            migrationBuilder.DropColumn(
                name: "staff_email",
                table: "tbl_managementStaff");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "tbl_managementStaff",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "tbl_managementStaff",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_name",
                table: "tbl_managementStaff",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "staff_number",
                table: "tbl_managementStaff",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "staff_name",
                table: "tbl_managementStaff",
                newName: "Email");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "tbl_managementStaff",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "tbl_managementStaff",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "tbl_managementStaff");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "tbl_managementStaff");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "tbl_managementStaff",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tbl_managementStaff",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "tbl_managementStaff",
                newName: "user_name");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tbl_managementStaff",
                newName: "staff_number");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "tbl_managementStaff",
                newName: "staff_name");

            migrationBuilder.AddColumn<string>(
                name: "joining_date",
                table: "tbl_managementStaff",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "staff_email",
                table: "tbl_managementStaff",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
