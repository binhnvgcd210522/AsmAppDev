using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsmAppDev.Migrations
{
    /// <inheritdoc />
    public partial class AddReCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "89bf0a61-e7cf-4efe-a7c8-83631a253554");

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "89bf0a61-e7cf-4efe-a7c8-83631a253554");

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: "89bf0a61-e7cf-4efe-a7c8-83631a253554");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Jobs");
        }
    }
}
