using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiSchool.Migrations
{
    /// <inheritdoc />
    public partial class createDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseName = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.GUID);
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfficeName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    OfficeLocation = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.GUID);
                });

            migrationBuilder.CreateTable(
                name: "Particpants",
                columns: table => new
                {
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    LName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Particpants", x => x.GUID);
                });

            migrationBuilder.CreateTable(
                name: "PermissionGroups",
                columns: table => new
                {
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionGroups", x => x.GUID);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SUN = table.Column<bool>(type: "bit", nullable: false),
                    MON = table.Column<bool>(type: "bit", nullable: false),
                    TUE = table.Column<bool>(type: "bit", nullable: false),
                    WED = table.Column<bool>(type: "bit", nullable: false),
                    THU = table.Column<bool>(type: "bit", nullable: false),
                    FRI = table.Column<bool>(type: "bit", nullable: false),
                    SAT = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.GUID);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_Reviews_Courses_CourseGUID",
                        column: x => x.CourseGUID,
                        principalTable: "Courses",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    LName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    OfficeGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_Instructors_Offices_OfficeGUID",
                        column: x => x.OfficeGUID,
                        principalTable: "Offices",
                        principalColumn: "GUID");
                });

            migrationBuilder.CreateTable(
                name: "Coporates",
                columns: table => new
                {
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coporates", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_Coporates_Particpants_GUID",
                        column: x => x.GUID,
                        principalTable: "Particpants",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Individuals",
                columns: table => new
                {
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    University = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfGraduation = table.Column<int>(type: "int", nullable: false),
                    IsIntern = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Individuals", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_Individuals_Particpants_GUID",
                        column: x => x.GUID,
                        principalTable: "Particpants",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermissionGroupGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_Users_PermissionGroups_PermissionGroupGUID",
                        column: x => x.PermissionGroupGUID,
                        principalTable: "PermissionGroups",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    GUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SectionName = table.Column<string>(type: "Varchar(255)", maxLength: 255, nullable: false),
                    CourseGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstructorGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduleGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time(0)", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.GUID);
                    table.ForeignKey(
                        name: "FK_Sections_Courses_CourseGUID",
                        column: x => x.CourseGUID,
                        principalTable: "Courses",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sections_Instructors_InstructorGUID",
                        column: x => x.InstructorGUID,
                        principalTable: "Instructors",
                        principalColumn: "GUID");
                    table.ForeignKey(
                        name: "FK_Sections_Schedules_ScheduleGUID",
                        column: x => x.ScheduleGUID,
                        principalTable: "Schedules",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    SectionGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParticipantGUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => new { x.SectionGUID, x.ParticipantGUID });
                    table.ForeignKey(
                        name: "FK_Enrollments_Particpants_ParticipantGUID",
                        column: x => x.ParticipantGUID,
                        principalTable: "Particpants",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Sections_SectionGUID",
                        column: x => x.SectionGUID,
                        principalTable: "Sections",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_ParticipantGUID",
                table: "Enrollments",
                column: "ParticipantGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_OfficeGUID",
                table: "Instructors",
                column: "OfficeGUID",
                unique: true,
                filter: "[OfficeGUID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CourseGUID",
                table: "Reviews",
                column: "CourseGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_CourseGUID",
                table: "Sections",
                column: "CourseGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_InstructorGUID",
                table: "Sections",
                column: "InstructorGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_ScheduleGUID",
                table: "Sections",
                column: "ScheduleGUID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PermissionGroupGUID",
                table: "Users",
                column: "PermissionGroupGUID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coporates");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Individuals");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Particpants");

            migrationBuilder.DropTable(
                name: "PermissionGroups");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Offices");
        }
    }
}
