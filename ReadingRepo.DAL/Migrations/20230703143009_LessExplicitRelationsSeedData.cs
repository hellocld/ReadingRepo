using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReadingRepo.DAL.Migrations
{
    /// <inheritdoc />
    public partial class LessExplicitRelationsSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("84f3f98b-82e5-445f-8e8c-df30afcd7cbf"), "Groucho", "Marx" },
                    { new Guid("f135fec5-71b8-4be7-8d55-7301d6f1ecab"), "Harpo", "Marx" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "CoverImageUri", "Isbn", "OpenLibraryId", "Pages", "PublishDate", "Title" },
                values: new object[] { new Guid("c7882c3f-98dc-4553-9835-65872cf9d3a4"), null, null, null, 68, new DateTime(1933, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hail Freedonia" });

            migrationBuilder.InsertData(
                table: "AuthorBook",
                columns: new[] { "AuthorsAuthorId", "BooksBookId" },
                values: new object[,]
                {
                    { new Guid("84f3f98b-82e5-445f-8e8c-df30afcd7cbf"), new Guid("c7882c3f-98dc-4553-9835-65872cf9d3a4") },
                    { new Guid("f135fec5-71b8-4be7-8d55-7301d6f1ecab"), new Guid("c7882c3f-98dc-4553-9835-65872cf9d3a4") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { new Guid("84f3f98b-82e5-445f-8e8c-df30afcd7cbf"), new Guid("c7882c3f-98dc-4553-9835-65872cf9d3a4") });

            migrationBuilder.DeleteData(
                table: "AuthorBook",
                keyColumns: new[] { "AuthorsAuthorId", "BooksBookId" },
                keyValues: new object[] { new Guid("f135fec5-71b8-4be7-8d55-7301d6f1ecab"), new Guid("c7882c3f-98dc-4553-9835-65872cf9d3a4") });

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("84f3f98b-82e5-445f-8e8c-df30afcd7cbf"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("f135fec5-71b8-4be7-8d55-7301d6f1ecab"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("c7882c3f-98dc-4553-9835-65872cf9d3a4"));
        }
    }
}
