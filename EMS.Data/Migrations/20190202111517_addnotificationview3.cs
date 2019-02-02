using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EMS.Data.Migrations
{
    public partial class addnotificationview3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotificationViewEmployees_Employees_EmployeeId",
                table: "NotificationViewEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationViewEmployees_Notifications_NotificationId",
                table: "NotificationViewEmployees");

            migrationBuilder.DropIndex(
                name: "IX_NotificationViewEmployees_EmployeeId",
                table: "NotificationViewEmployees");

            migrationBuilder.DropIndex(
                name: "IX_NotificationViewEmployees_NotificationId",
                table: "NotificationViewEmployees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_NotificationViewEmployees_EmployeeId",
                table: "NotificationViewEmployees",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotificationViewEmployees_NotificationId",
                table: "NotificationViewEmployees",
                column: "NotificationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationViewEmployees_Employees_EmployeeId",
                table: "NotificationViewEmployees",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationViewEmployees_Notifications_NotificationId",
                table: "NotificationViewEmployees",
                column: "NotificationId",
                principalTable: "Notifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
