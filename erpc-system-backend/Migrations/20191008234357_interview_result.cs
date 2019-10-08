using Microsoft.EntityFrameworkCore.Migrations;

namespace erpc_system_backend.Migrations
{
    public partial class interview_result : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Result",
                table: "Interviews",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Result",
                table: "Interviews");
        }
    }
}
