using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineLearning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EnableCascadeDeleteForAssignments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgressTrackings_Assignments_AssignmentId",
                table: "ProgressTrackings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9663b29b-2c94-45e7-9114-699a256c7d8d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2ab5d0c-f805-41f4-bd81-9293e72b3976");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef95cf67-7d57-4b64-90e9-1dfd81ed7f68");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "379a03af-89d2-453e-a567-266dbdccbdf3", "3", "Admin", "ADMIN" },
                    { "5b1b5030-acc6-40a9-ad7d-72334d2e9af5", "1", "Student", "STUDENT" },
                    { "f69570b0-1b58-47b8-90bb-f591dc5eb0e4", "2", "Instructor", "INSTRUCTOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProgressTrackings_Assignments_AssignmentId",
                table: "ProgressTrackings",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgressTrackings_Assignments_AssignmentId",
                table: "ProgressTrackings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "379a03af-89d2-453e-a567-266dbdccbdf3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b1b5030-acc6-40a9-ad7d-72334d2e9af5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f69570b0-1b58-47b8-90bb-f591dc5eb0e4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9663b29b-2c94-45e7-9114-699a256c7d8d", "1", "Student", "STUDENT" },
                    { "a2ab5d0c-f805-41f4-bd81-9293e72b3976", "2", "Instructor", "INSTRUCTOR" },
                    { "ef95cf67-7d57-4b64-90e9-1dfd81ed7f68", "3", "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProgressTrackings_Assignments_AssignmentId",
                table: "ProgressTrackings",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
