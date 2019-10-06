﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace erpc_system_backend.Migrations
{
    public partial class employeedescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Employees");
        }
    }
}
