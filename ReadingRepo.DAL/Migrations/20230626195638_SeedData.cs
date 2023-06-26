using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReadingRepo.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AuthorGroups",
                columns: new[] { "AuthorId", "GroupId" },
                values: new object[,]
                {
                    { new Guid("3ee68521-9568-42ed-8c1b-278556e5710c"), new Guid("ffc04136-7407-4295-bc67-02174f07bfc5") },
                    { new Guid("d07b902d-f019-4763-b3e6-a9339dd47e82"), new Guid("ffc04136-7407-4295-bc67-02174f07bfc5") }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("3ee68521-9568-42ed-8c1b-278556e5710c"), "Groucho", "Marx" },
                    { new Guid("d07b902d-f019-4763-b3e6-a9339dd47e82"), "Harpo", "Marx" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorGroupId", "CoverImageUri", "Isbn", "OpenLibraryId", "Pages", "PublishDate", "Title" },
                values: new object[] { new Guid("871704e5-a8aa-43be-a449-68221ff5d9a6"), new Guid("ffc04136-7407-4295-bc67-02174f07bfc5"), null, null, null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hail Freedonia" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorGroups",
                keyColumns: new[] { "AuthorId", "GroupId" },
                keyValues: new object[] { new Guid("3ee68521-9568-42ed-8c1b-278556e5710c"), new Guid("ffc04136-7407-4295-bc67-02174f07bfc5") });

            migrationBuilder.DeleteData(
                table: "AuthorGroups",
                keyColumns: new[] { "AuthorId", "GroupId" },
                keyValues: new object[] { new Guid("d07b902d-f019-4763-b3e6-a9339dd47e82"), new Guid("ffc04136-7407-4295-bc67-02174f07bfc5") });

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("3ee68521-9568-42ed-8c1b-278556e5710c"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("d07b902d-f019-4763-b3e6-a9339dd47e82"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("871704e5-a8aa-43be-a449-68221ff5d9a6"));
        }
    }
}
