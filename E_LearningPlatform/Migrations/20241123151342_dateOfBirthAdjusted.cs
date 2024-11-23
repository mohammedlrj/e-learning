using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_LearningPlatform.Migrations
{
    /// <inheritdoc />
    public partial class dateOfBirthAdjusted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ajhhdgs7-ec6d-4b88-9b20-5322fb1d94e1",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "94f2f9d9-6f13-4317-a6dd-4b072f8fdfa2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAIAAYagAAAAEJKx2ksb5TPECZi2NAvAszZvycd5S3IhRUfQevVqoUCQnDxx4n+nUkzzh6gxkgE3GQ==", new DateTime(2024, 11, 23, 15, 13, 41, 695, DateTimeKind.Utc).AddTicks(5584), "68cbaa08-a7b4-4c87-9107-2c6dbe51c928" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ajhhdgs7-ec6d-4b88-9b20-5322fb1d94e1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RegistrationDate", "SecurityStamp" },
                values: new object[] { "ed7833ea-cb75-4447-92c6-c75bd9d6523e", "AQAAAAIAAYagAAAAEC0DAxI5VUG8SYVeKY8LK9cRsq8DTrCzYfXcMd12YuwOJ2aKJKb/5u3fqi2/KGcS6A==", new DateTime(2024, 11, 23, 15, 5, 25, 395, DateTimeKind.Utc).AddTicks(5461), "65d4cc8c-c94c-4418-8104-7e9d859fb670" });
        }
    }
}
