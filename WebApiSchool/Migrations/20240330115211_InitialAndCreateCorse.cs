using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiSchool.Migrations
{
    /// <inheritdoc />
    public partial class InitialAndCreateCorse : Migration
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

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "GUID", "CourseName", "Price" },
                values: new object[] { new Guid("bbaaffb1-6ae6-4886-bcda-15161b61e985"), "HCi", 100m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
