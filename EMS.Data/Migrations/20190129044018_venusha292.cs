using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EMS.Data.Migrations
{
    public partial class venusha292 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TeamSchedules",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TeamSchedules",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SchDate",
                table: "TeamSchedules",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SchName",
                table: "TeamSchedules",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "TeamSchedules");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TeamSchedules");

            migrationBuilder.DropColumn(
                name: "SchDate",
                table: "TeamSchedules");

            migrationBuilder.DropColumn(
                name: "SchName",
                table: "TeamSchedules");
        }
    }
}
