using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadingRepo.DAL.Migrations
{
    /// <inheritdoc />
    public partial class LogBookRelation : Migration
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
                column: "BookId",
                unique: true);
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
                column: "BookId");
        }
    }
}
