using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_LearningPlatform.Migrations
{
    /// <inheritdoc />
    public partial class seedAdminRoleFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ajhhdgs7-ec6d-4b88-9b20-5322fb1d94e1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CIN", "ConcurrencyStamp", "DateOfBirth", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "RegistrationDate", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ajhhdgs7-ec6d-4b88-9b20-5322fb1d94e1", 0, "F123456", "94f2f9d9-6f13-4317-a6dd-4b072f8fdfa2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "admin@elearning.com", true, "Super", "Male", "Admin", false, null, "ADMIN@ELEARNING.COM", "SUPERADMIN", "AQAAAAIAAYagAAAAEJKx2ksb5TPECZi2NAvAszZvycd5S3IhRUfQevVqoUCQnDxx4n+nUkzzh6gxkgE3GQ==", "0634567891", false, "images/pic.png", new DateTime(2024, 11, 23, 15, 13, 41, 695, DateTimeKind.Utc).AddTicks(5584), "68cbaa08-a7b4-4c87-9107-2c6dbe51c928", 1, false, "superadmin" });
        }
    }
}
