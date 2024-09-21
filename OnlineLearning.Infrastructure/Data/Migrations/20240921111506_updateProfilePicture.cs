using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineLearning.MVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateProfilePicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<byte[]>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "50a64497-bf45-48c3-972b-40976a7b8395", "3", "Admin", "ADMIN" },
                    { "7f1ecfef-4e25-404b-80b8-c5532a51ef6f", "2", "Instructor", "INSTRUCTOR" },
                    { "ee05ca03-74b4-42fd-84fa-389286fb52ad", "1", "Student", "STUDENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50a64497-bf45-48c3-972b-40976a7b8395");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f1ecfef-4e25-404b-80b8-c5532a51ef6f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee05ca03-74b4-42fd-84fa-389286fb52ad");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

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
    }
}
