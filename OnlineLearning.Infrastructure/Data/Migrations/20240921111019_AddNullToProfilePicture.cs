using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineLearning.MVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNullToProfilePicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "415280b7-cc99-4301-a845-71b2c24b4d81");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d276d82-48a3-4dbe-af76-f0a7e36c367b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c022c63f-86e1-4b5c-ab84-b76884256040");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b00b8be-a366-4bc5-ba74-2c71de88191b", "3", "Admin", "ADMIN" },
                    { "3d4a2df8-a12d-47f5-8874-4311c4a93650", "1", "Student", "STUDENT" },
                    { "d11df4b8-d3cb-48b6-9cd9-e29d6c20421f", "2", "Instructor", "INSTRUCTOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b00b8be-a366-4bc5-ba74-2c71de88191b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d4a2df8-a12d-47f5-8874-4311c4a93650");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d11df4b8-d3cb-48b6-9cd9-e29d6c20421f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "415280b7-cc99-4301-a845-71b2c24b4d81", "1", "Student", "STUDENT" },
                    { "7d276d82-48a3-4dbe-af76-f0a7e36c367b", "2", "Admin", "ADMIN" },
                    { "c022c63f-86e1-4b5c-ab84-b76884256040", "2", "Instructor", "INSTRUCTOR" }
                });
        }
    }
}
