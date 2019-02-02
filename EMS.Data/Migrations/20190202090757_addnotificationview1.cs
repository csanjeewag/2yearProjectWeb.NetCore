using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EMS.Data.Migrations
{
    public partial class addnotificationview1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotificationViewEmployee_Employees_EmployeeId",
                table: "NotificationViewEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationViewEmployee_Notifications_NotificationId",
                table: "NotificationViewEmployee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationViewEmployee",
                table: "NotificationViewEmployee");

            migrationBuilder.RenameTable(
                name: "NotificationViewEmployee",
                newName: "NotificationViewEmployees");

            migrationBuilder.RenameIndex(
                name: "IX_NotificationViewEmployee_NotificationId",
                table: "NotificationViewEmployees",
                newName: "IX_NotificationViewEmployees_NotificationId");

            migrationBuilder.RenameIndex(
                name: "IX_NotificationViewEmployee_EmployeeId",
                table: "NotificationViewEmployees",
                newName: "IX_NotificationViewEmployees_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationViewEmployees",
                table: "NotificationViewEmployees",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotificationViewEmployees_Employees_EmployeeId",
                table: "NotificationViewEmployees");

            migrationBuilder.DropForeignKey(
                name: "FK_NotificationViewEmployees_Notifications_NotificationId",
                table: "NotificationViewEmployees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificationViewEmployees",
                table: "NotificationViewEmployees");

            migrationBuilder.RenameTable(
                name: "NotificationViewEmployees",
                newName: "NotificationViewEmployee");

            migrationBuilder.RenameIndex(
                name: "IX_NotificationViewEmployees_NotificationId",
                table: "NotificationViewEmployee",
                newName: "IX_NotificationViewEmployee_NotificationId");

            migrationBuilder.RenameIndex(
                name: "IX_NotificationViewEmployees_EmployeeId",
                table: "NotificationViewEmployee",
                newName: "IX_NotificationViewEmployee_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificationViewEmployee",
                table: "NotificationViewEmployee",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationViewEmployee_Employees_EmployeeId",
                table: "NotificationViewEmployee",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotificationViewEmployee_Notifications_NotificationId",
                table: "NotificationViewEmployee",
                column: "NotificationId",
                principalTable: "Notifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
