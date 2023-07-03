using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadingRepo.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedReadingLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ReadingLogs",
                columns: new[] { "Id", "BookId", "EndDate", "StartDate", "State" },
                values: new object[] { new Guid("3b253915-1e10-477c-92ab-effb0cb896b4"), new Guid("c7882c3f-98dc-4553-9835-65872cf9d3a4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ReadingLogs",
                keyColumn: "Id",
                keyValue: new Guid("3b253915-1e10-477c-92ab-effb0cb896b4"));
        }
    }
}
