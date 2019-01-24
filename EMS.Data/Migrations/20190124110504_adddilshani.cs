using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EMS.Data.Migrations
{
    public partial class adddilshani : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventTypeId",
                table: "Eventtypes");

            migrationBuilder.RenameColumn(
                name: "EventStartDate",
                table: "Event",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "EventName",
                table: "Event",
                newName: "Venue");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Event",
                newName: "NumberOfTeams");

            migrationBuilder.RenameColumn(
                name: "EventEndDate",
                table: "Event",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "EventClosingDate",
                table: "Event",
                newName: "ClosingDate");

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventTitle",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsFamilyMembersAllowed",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Liquor",
                table: "Event",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EventAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClosingDate = table.Column<bool>(nullable: false),
                    Destination = table.Column<bool>(nullable: false),
                    EndDate = table.Column<bool>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    IsFamilyMembersAllowed = table.Column<bool>(nullable: false),
                    Liquor = table.Column<bool>(nullable: false),
                    NumberOfTeams = table.Column<bool>(nullable: false),
                    Venue = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventAttributes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventAttributes");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "EventTitle",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "IsFamilyMembersAllowed",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Liquor",
                table: "Event");

            migrationBuilder.RenameColumn(
                name: "Venue",
                table: "Event",
                newName: "EventName");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Event",
                newName: "EventStartDate");

            migrationBuilder.RenameColumn(
                name: "NumberOfTeams",
                table: "Event",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Event",
                newName: "EventEndDate");

            migrationBuilder.RenameColumn(
                name: "ClosingDate",
                table: "Event",
                newName: "EventClosingDate");

            migrationBuilder.AddColumn<string>(
                name: "EventTypeId",
                table: "Eventtypes",
                nullable: true);
        }
    }
}
