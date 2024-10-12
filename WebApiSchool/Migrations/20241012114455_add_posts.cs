using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApiSchool.Migrations
{
    /// <inheritdoc />
    public partial class addposts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "GUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("172a6883-7a3e-48e7-9f20-5be7110d8323"), new Guid("b1b62bb0-17b6-4401-a0c7-54c8279b8d0d"), "This is the content of the second post.", new DateTime(2024, 10, 12, 11, 44, 55, 284, DateTimeKind.Utc).AddTicks(1245), "Post6", null },
                    { new Guid("3ca0473e-e83c-4bed-860b-72aaafd8d37c"), new Guid("02f588e5-942d-4dbe-a6ae-046a7f60e9e4"), "This is the content of the first post.", new DateTime(2024, 10, 12, 11, 44, 55, 284, DateTimeKind.Utc).AddTicks(1241), "Post5", null },
                    { new Guid("504a976c-5a73-4e7f-afe8-c45784ba932f"), new Guid("b1b62bb0-17b6-4401-a0c7-54c8279b8d0d"), "This is the content of the second post.", new DateTime(2024, 10, 12, 11, 44, 55, 284, DateTimeKind.Utc).AddTicks(1210), "Post2", null },
                    { new Guid("8c144e1e-52cf-427a-bfb1-c9349051743f"), new Guid("02f588e5-942d-4dbe-a6ae-046a7f60e9e4"), "This is the content of the first post.", new DateTime(2024, 10, 12, 11, 44, 55, 284, DateTimeKind.Utc).AddTicks(1193), "Post1", null },
                    { new Guid("9598e5f7-afa9-4e77-b41a-1ce3fd25b7f7"), new Guid("02f588e5-942d-4dbe-a6ae-046a7f60e9e4"), "This is the content of the first post.", new DateTime(2024, 10, 12, 11, 44, 55, 284, DateTimeKind.Utc).AddTicks(1233), "Post3", null },
                    { new Guid("c1136f7f-c1b4-4cc3-9c4f-43becc9cf8b2"), new Guid("b1b62bb0-17b6-4401-a0c7-54c8279b8d0d"), "This is the content of the second post.", new DateTime(2024, 10, 12, 11, 44, 55, 284, DateTimeKind.Utc).AddTicks(1237), "Post4", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Title",
                table: "Posts",
                column: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
