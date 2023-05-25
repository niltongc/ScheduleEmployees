using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeSchedule.Migrations
{
    /// <inheritdoc />
    public partial class TableWithoutIslogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLogin",
                table: "Schedules");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLogin",
                table: "Schedules",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
