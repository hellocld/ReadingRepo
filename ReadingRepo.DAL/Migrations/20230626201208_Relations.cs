using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReadingRepo.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "IX_AuthorGroups_AuthorId",
                table: "AuthorGroups",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorGroupBook_AuthorGroupsGroupId_AuthorGroupsAuthorId",
                table: "AuthorGroupBook",
                columns: new[] { "AuthorGroupsGroupId", "AuthorGroupsAuthorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorGroups_Authors_AuthorId",
                table: "AuthorGroups",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorGroups_Authors_AuthorId",
                table: "AuthorGroups");

            migrationBuilder.DropTable(
                name: "AuthorGroupBook");

            migrationBuilder.DropIndex(
                name: "IX_AuthorGroups_AuthorId",
                table: "AuthorGroups");

            migrationBuilder.DeleteData(
                table: "AuthorGroups",
                keyColumns: new[] { "AuthorId", "GroupId" },
                keyValues: new object[] { new Guid("4bc7e5d0-62b4-4e2f-98cd-2bb99a13f19b"), new Guid("b0b463fd-a805-43da-82f6-7d30353c8e74") });

            migrationBuilder.DeleteData(
                table: "AuthorGroups",
                keyColumns: new[] { "AuthorId", "GroupId" },
                keyValues: new object[] { new Guid("982bb77d-8041-491c-b3f3-baef19729c79"), new Guid("b0b463fd-a805-43da-82f6-7d30353c8e74") });

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("72e54d7d-20a7-4a7a-8795-df77c6f48fee"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("4bc7e5d0-62b4-4e2f-98cd-2bb99a13f19b"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("982bb77d-8041-491c-b3f3-baef19729c79"));

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
    }
}
