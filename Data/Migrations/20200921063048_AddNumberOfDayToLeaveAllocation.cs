using Microsoft.EntityFrameworkCore.Migrations;

namespace Leave_Management.Data.Migrations
{
    public partial class AddNumberOfDayToLeaveAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfDays",
                table: "LeaveAllocations",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfDays",
                table: "LeaveAllocations");
        }
    }
}
