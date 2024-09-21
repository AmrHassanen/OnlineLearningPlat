using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineLearning.MVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateApplicationUserToAcceptProfilePicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17b8e52d-9bdf-43da-9eeb-99cadb58a83b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d801cdd-1c52-4ac0-94af-59e2f47dbfda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64765cf8-508e-45e0-909d-31fdaa6057c4");

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17b8e52d-9bdf-43da-9eeb-99cadb58a83b", "2", "Admin", "ADMIN" },
                    { "4d801cdd-1c52-4ac0-94af-59e2f47dbfda", "1", "Student", "STUDENT" },
                    { "64765cf8-508e-45e0-909d-31fdaa6057c4", "2", "Instructor", "INSTRUCTOR" }
                });
        }
    }
}
