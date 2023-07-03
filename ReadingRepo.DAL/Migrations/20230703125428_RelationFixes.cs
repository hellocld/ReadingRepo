using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReadingRepo.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RelationFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorGroupBook");

            migrationBuilder.DropTable(
                name: "AuthorGroups");

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("4bc7e5d0-62b4-4e2f-98cd-2bb99a13f19b"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("982bb77d-8041-491c-b3f3-baef19729c79"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("72e54d7d-20a7-4a7a-8795-df77c6f48fee"));

            migrationBuilder.DropColumn(
                name: "AuthorGroupId",
                table: "Books");

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    AuthorsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BooksId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.AuthorsId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BooksId",
                table: "AuthorBook",
                column: "BooksId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBook");

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorGroupId",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "AuthorGroups",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AuthorId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorGroups", x => new { x.GroupId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_AuthorGroups_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorGroupBook",
                columns: table => new
                {
                    BooksId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AuthorGroupsGroupId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AuthorGroupsAuthorId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorGroupBook", x => new { x.BooksId, x.AuthorGroupsGroupId, x.AuthorGroupsAuthorId });
                    table.ForeignKey(
                        name: "FK_AuthorGroupBook_AuthorGroups_AuthorGroupsGroupId_AuthorGroupsAuthorId",
                        columns: x => new { x.AuthorGroupsGroupId, x.AuthorGroupsAuthorId },
                        principalTable: "AuthorGroups",
                        principalColumns: new[] { "GroupId", "AuthorId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorGroupBook_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("4bc7e5d0-62b4-4e2f-98cd-2bb99a13f19b"), "Groucho", "Marx" },
                    { new Guid("982bb77d-8041-491c-b3f3-baef19729c79"), "Harpo", "Marx" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorGroupId", "CoverImageUri", "Isbn", "OpenLibraryId", "Pages", "PublishDate", "Title" },
                values: new object[] { new Guid("72e54d7d-20a7-4a7a-8795-df77c6f48fee"), new Guid("b0b463fd-a805-43da-82f6-7d30353c8e74"), null, null, null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hail Freedonia" });

            migrationBuilder.InsertData(
                table: "AuthorGroups",
                columns: new[] { "AuthorId", "GroupId" },
                values: new object[,]
                {
                    { new Guid("4bc7e5d0-62b4-4e2f-98cd-2bb99a13f19b"), new Guid("b0b463fd-a805-43da-82f6-7d30353c8e74") },
                    { new Guid("982bb77d-8041-491c-b3f3-baef19729c79"), new Guid("b0b463fd-a805-43da-82f6-7d30353c8e74") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorGroupBook_AuthorGroupsGroupId_AuthorGroupsAuthorId",
                table: "AuthorGroupBook",
                columns: new[] { "AuthorGroupsGroupId", "AuthorGroupsAuthorId" });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorGroups_AuthorId",
                table: "AuthorGroups",
                column: "AuthorId");
        }
    }
}
