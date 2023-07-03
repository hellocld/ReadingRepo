using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadingRepo.DAL.Migrations
{
    /// <inheritdoc />
    public partial class LogManyToOneBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ReadingLogs_BookId",
                table: "ReadingLogs");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingLogs_BookId",
                table: "ReadingLogs",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ReadingLogs_BookId",
                table: "ReadingLogs");

            migrationBuilder.CreateIndex(
                name: "IX_ReadingLogs_BookId",
                table: "ReadingLogs",
                column: "BookId",
                unique: true);
        }
    }
}
