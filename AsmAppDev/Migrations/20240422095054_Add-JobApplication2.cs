using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsmAppDev.Migrations
{
    /// <inheritdoc />
    public partial class AddJobApplication2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_AspNetUsers_JobSeekerId",
                table: "JobApplications");

            migrationBuilder.RenameColumn(
                name: "JobSeekerId",
                table: "JobApplications",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplications_JobSeekerId",
                table: "JobApplications",
                newName: "IX_JobApplications_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_AspNetUsers_UserId",
                table: "JobApplications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_AspNetUsers_UserId",
                table: "JobApplications");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "JobApplications",
                newName: "JobSeekerId");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplications_UserId",
                table: "JobApplications",
                newName: "IX_JobApplications_JobSeekerId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_AspNetUsers_JobSeekerId",
                table: "JobApplications",
                column: "JobSeekerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
