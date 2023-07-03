using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadingRepo.DAL.Migrations
{
    /// <inheritdoc />
    public partial class BookLogRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ReadingLogs_BookId",
                table: "ReadingLogs",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReadingLogs_Books_BookId",
                table: "ReadingLogs",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReadingLogs_Books_BookId",
                table: "ReadingLogs");

            migrationBuilder.DropIndex(
                name: "IX_ReadingLogs_BookId",
                table: "ReadingLogs");
        }
    }
}
