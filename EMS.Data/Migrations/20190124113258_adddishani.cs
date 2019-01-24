using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EMS.Data.Migrations
{
    public partial class adddishani : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTasks_Employees_Id",
                table: "EmployeeTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskInformations_Tasks_Task",
                table: "TaskInformations");

            migrationBuilder.RenameColumn(
                name: "Task",
                table: "TaskInformations",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "TaskInformations",
                newName: "InfoDescription");

            migrationBuilder.RenameColumn(
                name: "FileID",
                table: "TaskInformations",
                newName: "InfoID");

            migrationBuilder.RenameIndex(
                name: "IX_TaskInformations_Task",
                table: "TaskInformations",
                newName: "IX_TaskInformations_EmployeeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EmployeeTasks",
                newName: "EId");

            migrationBuilder.AddColumn<float>(
                name: "ActualCost",
                table: "Tasks",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "TaskInformations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TaskInformations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TaskInformations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsComplete",
                table: "TaskInformations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "TaskInformations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactType = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "ContactDetails",
                columns: table => new
                {
                    ContactDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Contact = table.Column<int>(nullable: true),
                    ContactDescription = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Number1 = table.Column<int>(nullable: false),
                    Number2 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetails", x => x.ContactDetailId);
                    table.ForeignKey(
                        name: "FK_ContactDetails_Contacts_Contact",
                        column: x => x.Contact,
                        principalTable: "Contacts",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskInformations_ContactId",
                table: "TaskInformations",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskInformations_TaskId",
                table: "TaskInformations",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_Contact",
                table: "ContactDetails",
                column: "Contact");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTasks_Employees_EId",
                table: "EmployeeTasks",
                column: "EId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskInformations_Contacts_ContactId",
                table: "TaskInformations",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskInformations_Employees_EmployeeId",
                table: "TaskInformations",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskInformations_Tasks_TaskId",
                table: "TaskInformations",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTasks_Employees_EId",
                table: "EmployeeTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskInformations_Contacts_ContactId",
                table: "TaskInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskInformations_Employees_EmployeeId",
                table: "TaskInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskInformations_Tasks_TaskId",
                table: "TaskInformations");

            migrationBuilder.DropTable(
                name: "ContactDetails");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_TaskInformations_ContactId",
                table: "TaskInformations");

            migrationBuilder.DropIndex(
                name: "IX_TaskInformations_TaskId",
                table: "TaskInformations");

            migrationBuilder.DropColumn(
                name: "ActualCost",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "TaskInformations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TaskInformations");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TaskInformations");

            migrationBuilder.DropColumn(
                name: "IsComplete",
                table: "TaskInformations");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "TaskInformations");

            migrationBuilder.RenameColumn(
                name: "InfoDescription",
                table: "TaskInformations",
                newName: "FileName");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "TaskInformations",
                newName: "Task");

            migrationBuilder.RenameColumn(
                name: "InfoID",
                table: "TaskInformations",
                newName: "FileID");

            migrationBuilder.RenameIndex(
                name: "IX_TaskInformations_EmployeeId",
                table: "TaskInformations",
                newName: "IX_TaskInformations_Task");

            migrationBuilder.RenameColumn(
                name: "EId",
                table: "EmployeeTasks",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTasks_Employees_Id",
                table: "EmployeeTasks",
                column: "Id",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskInformations_Tasks_Task",
                table: "TaskInformations",
                column: "Task",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
