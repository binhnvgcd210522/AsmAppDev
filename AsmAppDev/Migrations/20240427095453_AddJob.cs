using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsmAppDev.Migrations
{
    /// <inheritdoc />
    public partial class AddJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JobApplications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DayApply",
                table: "JobApplications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DayApply",
                table: "JobApplications",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "JobApplications",
                columns: new[] { "Id", "DayApply", "Email", "JobId" },
                values: new object[] { 1, new DateTime(2024, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "binh@gmail.com", 18 });
        }
    }
}
