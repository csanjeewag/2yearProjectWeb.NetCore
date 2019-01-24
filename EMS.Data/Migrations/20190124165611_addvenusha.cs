using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EMS.Data.Migrations
{
    public partial class addvenusha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CricketTeams");

            migrationBuilder.CreateTable(
                name: "cricketTeamRegisters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    LiquorCount = table.Column<int>(nullable: false),
                    Registerdate = table.Column<DateTime>(nullable: false),
                    TeamName = table.Column<string>(nullable: true),
                    VegeCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cricketTeamRegisters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CricketTeamRegisterId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMembers_cricketTeamRegisters_CricketTeamRegisterId",
                        column: x => x.CricketTeamRegisterId,
                        principalTable: "cricketTeamRegisters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_CricketTeamRegisterId",
                table: "TeamMembers",
                column: "CricketTeamRegisterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropTable(
                name: "cricketTeamRegisters");

            migrationBuilder.CreateTable(
                name: "CricketTeams",
                columns: table => new
                {
                    CriTeamID = table.Column<string>(nullable: false),
                    CriTeamCaptionContact = table.Column<string>(nullable: true),
                    CriTeamCaptionEmail = table.Column<string>(nullable: true),
                    CriTeamCaptionName = table.Column<string>(nullable: true),
                    CriTeamName = table.Column<string>(nullable: true),
                    CriTeamNonVegitarion = table.Column<string>(nullable: true),
                    CriTeamParticipations = table.Column<string>(nullable: true),
                    CriTeamVegitarion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CricketTeams", x => x.CriTeamID);
                });
        }
    }
}
