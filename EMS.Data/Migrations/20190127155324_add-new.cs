using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EMS.Data.Migrations
{
    public partial class addnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "Departments",
                columns: table => new
                {
                    DprtId = table.Column<string>(nullable: false),
                    DprtName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DprtId);
                });

            migrationBuilder.CreateTable(
                name: "EventAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActualCost = table.Column<bool>(nullable: false),
                    BudgetedCost = table.Column<bool>(nullable: false),
                    ClosingDate = table.Column<bool>(nullable: false),
                    Destination = table.Column<bool>(nullable: false),
                    EndDate = table.Column<bool>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    IsFamilyMembersAllowed = table.Column<bool>(nullable: false),
                    Liquor = table.Column<bool>(nullable: false),
                    MainOrganiZer = table.Column<bool>(nullable: false),
                    NumberOfTeams = table.Column<bool>(nullable: false),
                    Summary = table.Column<bool>(nullable: false),
                    Venue = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eventtypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventTypeDescription = table.Column<string>(nullable: true),
                    EventTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventtypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FrontPages",
                columns: table => new
                {
                    CriEventId = table.Column<string>(nullable: false),
                    CriEventContent1 = table.Column<string>(nullable: true),
                    CriEventContent2 = table.Column<string>(nullable: true),
                    CriEventDate = table.Column<DateTime>(nullable: false),
                    CriEventDeadLine = table.Column<DateTime>(nullable: false),
                    CriEventMainTopic = table.Column<string>(nullable: true),
                    CriEventPlace = table.Column<string>(nullable: true),
                    CriEventSubTopic = table.Column<string>(nullable: true),
                    CriEventTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrontPages", x => x.CriEventId);
                });

            migrationBuilder.CreateTable(
                name: "OneDayTripRegistrants",
                columns: table => new
                {
                    PKey = table.Column<string>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: true),
                    EventId = table.Column<string>(nullable: true),
                    NumberOfFamilyMembers = table.Column<string>(nullable: true),
                    TransportationMode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneDayTripRegistrants", x => x.PKey);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionId = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    PositionDis = table.Column<string>(nullable: true),
                    PositionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    PrId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(nullable: false),
                    ProjectDescription = table.Column<string>(nullable: true),
                    ProjectId = table.Column<string>(nullable: true),
                    ProjectName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.PrId);
                });

            migrationBuilder.CreateTable(
                name: "RegistrationAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Accomadation = table.Column<bool>(nullable: false),
                    Dob = table.Column<bool>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    Gender = table.Column<bool>(nullable: false),
                    MealType = table.Column<bool>(nullable: false),
                    Nic = table.Column<bool>(nullable: false),
                    SpouseDob = table.Column<bool>(nullable: false),
                    SpouseName = table.Column<bool>(nullable: false),
                    SpouseNic = table.Column<bool>(nullable: false),
                    TransportationMode = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<int>(nullable: false),
                    team1 = table.Column<int>(nullable: false),
                    team10 = table.Column<int>(nullable: false),
                    team11 = table.Column<int>(nullable: false),
                    team12 = table.Column<int>(nullable: false),
                    team13 = table.Column<int>(nullable: false),
                    team14 = table.Column<int>(nullable: false),
                    team15 = table.Column<int>(nullable: false),
                    team16 = table.Column<int>(nullable: false),
                    team2 = table.Column<int>(nullable: false),
                    team3 = table.Column<int>(nullable: false),
                    team4 = table.Column<int>(nullable: false),
                    team5 = table.Column<int>(nullable: false),
                    team6 = table.Column<int>(nullable: false),
                    team7 = table.Column<int>(nullable: false),
                    team8 = table.Column<int>(nullable: false),
                    team9 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSchedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    EmpName = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.EmpName);
                });

            migrationBuilder.CreateTable(
                name: "TwoDayTripRegistrant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Accomadation = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<string>(nullable: true),
                    EventId = table.Column<string>(nullable: true),
                    MealTypeNonVegi = table.Column<string>(nullable: true),
                    MealTypeVegi = table.Column<string>(nullable: true),
                    NumberOfFamilyMembers = table.Column<string>(nullable: true),
                    PKey = table.Column<string>(nullable: true),
                    TransportationMode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TwoDayTripRegistrant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactDetails",
                columns: table => new
                {
                    ContactDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    ContactContactId = table.Column<int>(nullable: false),
                    ContactDescription = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Number1 = table.Column<int>(nullable: false),
                    Number2 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetails", x => x.ContactDetailId);
                    table.ForeignKey(
                        name: "FK_ContactDetails_Contacts_ContactContactId",
                        column: x => x.ContactContactId,
                        principalTable: "Contacts",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActualCost = table.Column<int>(nullable: false),
                    BudgetedCost = table.Column<int>(nullable: false),
                    ClosingDate = table.Column<DateTime>(nullable: false),
                    Destination = table.Column<string>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: false),
                    EventDescription = table.Column<string>(nullable: true),
                    EventImageUrl = table.Column<string>(nullable: true),
                    EventTitle = table.Column<string>(nullable: true),
                    EventTypeId = table.Column<int>(nullable: false),
                    IsFamilyMembersAllowed = table.Column<string>(nullable: true),
                    Liquor = table.Column<string>(nullable: true),
                    MainOrganiZer = table.Column<int>(nullable: false),
                    NumberOfTeams = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Summary = table.Column<string>(nullable: true),
                    Venue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_Eventtypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "Eventtypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentDprtId = table.Column<string>(nullable: true),
                    EmpAddress1 = table.Column<string>(nullable: true),
                    EmpAddress2 = table.Column<string>(nullable: true),
                    EmpContact = table.Column<string>(nullable: true),
                    EmpEmail = table.Column<string>(nullable: true),
                    EmpGender = table.Column<string>(nullable: true),
                    EmpId = table.Column<string>(nullable: true),
                    EmpName = table.Column<string>(nullable: true),
                    EmpPassword = table.Column<string>(nullable: true),
                    EmpProfilePicture = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: true),
                    PositionId = table.Column<string>(nullable: true),
                    PositionPId = table.Column<string>(nullable: true),
                    ProjectPrId = table.Column<int>(nullable: false),
                    RegisterCode = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentDprtId",
                        column: x => x.DepartmentDprtId,
                        principalTable: "Departments",
                        principalColumn: "DprtId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Projects_ProjectPrId",
                        column: x => x.ProjectPrId,
                        principalTable: "Projects",
                        principalColumn: "PrId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CaptainEmails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description1 = table.Column<string>(nullable: true),
                    Description2 = table.Column<string>(nullable: true),
                    Description3 = table.Column<string>(nullable: true),
                    EventId = table.Column<int>(nullable: false),
                    SenderId = table.Column<int>(nullable: false),
                    Topic = table.Column<string>(nullable: true),
                    senderdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaptainEmails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaptainEmails_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActualCost = table.Column<float>(nullable: false),
                    AddDate = table.Column<DateTime>(nullable: false),
                    BudgetedCost = table.Column<float>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    TaskName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Tasks_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommentIn = table.Column<string>(nullable: true),
                    CommentTime = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    isActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventImages",
                columns: table => new
                {
                    ImageId = table.Column<string>(nullable: false),
                    Caption = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventImages", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_EventImages_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventImages_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Accomadation = table.Column<string>(nullable: true),
                    Dob = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    MealType = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Nic = table.Column<string>(nullable: true),
                    SpouseDob = table.Column<DateTime>(nullable: false),
                    SpouseName = table.Column<string>(nullable: true),
                    SpouseNic = table.Column<string>(nullable: true),
                    TransportationMode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegEmployees_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_TeamMembers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTasks",
                columns: table => new
                {
                    EId = table.Column<int>(nullable: false),
                    TaskId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTasks", x => new { x.EId, x.TaskId });
                    table.ForeignKey(
                        name: "FK_EmployeeTasks_Employees_EId",
                        column: x => x.EId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTasks_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskInformations",
                columns: table => new
                {
                    InfoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactContactId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    InfoDescription = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsComplete = table.Column<bool>(nullable: false),
                    TaskTaskId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskInformations", x => x.InfoID);
                    table.ForeignKey(
                        name: "FK_TaskInformations_Contacts_ContactContactId",
                        column: x => x.ContactContactId,
                        principalTable: "Contacts",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskInformations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskInformations_Tasks_TaskTaskId",
                        column: x => x.TaskTaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CaptainEmails_EventId",
                table: "CaptainEmails",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_EmployeeId",
                table: "Comments",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_EventId",
                table: "Comments",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_ContactContactId",
                table: "ContactDetails",
                column: "ContactContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentDprtId",
                table: "Employees",
                column: "DepartmentDprtId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ProjectPrId",
                table: "Employees",
                column: "ProjectPrId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTasks_TaskId",
                table: "EmployeeTasks",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventTypeId",
                table: "Event",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EventImages_EmployeeId",
                table: "EventImages",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EventImages_EventId",
                table: "EventImages",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_RegEmployees_EmployeeId",
                table: "RegEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_RegEmployees_EventId",
                table: "RegEmployees",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskInformations_ContactContactId",
                table: "TaskInformations",
                column: "ContactContactId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskInformations_EmployeeId",
                table: "TaskInformations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskInformations_TaskTaskId",
                table: "TaskInformations",
                column: "TaskTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_EventId",
                table: "Tasks",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_CricketTeamRegisterId",
                table: "TeamMembers",
                column: "CricketTeamRegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_EmployeeId",
                table: "TeamMembers",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CaptainEmails");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "ContactDetails");

            migrationBuilder.DropTable(
                name: "EmployeeTasks");

            migrationBuilder.DropTable(
                name: "EventAttributes");

            migrationBuilder.DropTable(
                name: "EventImages");

            migrationBuilder.DropTable(
                name: "FrontPages");

            migrationBuilder.DropTable(
                name: "OneDayTripRegistrants");

            migrationBuilder.DropTable(
                name: "RegEmployees");

            migrationBuilder.DropTable(
                name: "RegistrationAttributes");

            migrationBuilder.DropTable(
                name: "TaskInformations");

            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropTable(
                name: "TeamSchedules");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "TwoDayTripRegistrant");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "cricketTeamRegisters");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Eventtypes");
        }
    }
}
