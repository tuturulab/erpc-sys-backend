using Microsoft.EntityFrameworkCore.Migrations;

namespace erpc_system_backend.Migrations
{
    public partial class relateplan_acc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PlanId",
                table: "Accounts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_PlanId",
                table: "Accounts",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Plans_PlanId",
                table: "Accounts",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "PlanId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Plans_PlanId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_PlanId",
                table: "Accounts");

            migrationBuilder.AlterColumn<int>(
                name: "PlanId",
                table: "Accounts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
