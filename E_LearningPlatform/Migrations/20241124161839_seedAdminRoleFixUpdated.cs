using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_LearningPlatform.Migrations
{
    /// <inheritdoc />
    public partial class seedAdminRoleFixUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CIN", "ConcurrencyStamp", "DateOfBirth", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "RegistrationDate", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ajhhdgs7-ec6d-4b88-9b20-5322fb1d94e1", 0, "F123456", "b283a6a5-c19b-456b-9287-daf8af5ab62f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "admin@elearning.com", true, "Super", "Male", "Admin", false, null, "ADMIN@ELEARNING.COM", "SUPERADMIN", "AQAAAAIAAYagAAAAENtu9ZF1zR14zi412NRyaT3e8b2ZKpKEIg/SX67idgPjAhh4vIZhGv9TkfnGffv5MQ==", "0634567891", false, "images/pic.png", new DateTime(2024, 11, 24, 16, 18, 38, 710, DateTimeKind.Utc).AddTicks(1417), "c712684c-b1aa-4d81-8403-4aa3cd20039d", 1, false, "superadmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "ajhhdgs7-ec6d-4b88-9b20-5322fb1d94e1", "6ee2a5ea-ab9f-41a4-875e-fd4c1b142631" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "ajhhdgs7-ec6d-4b88-9b20-5322fb1d94e1", "6ee2a5ea-ab9f-41a4-875e-fd4c1b142631" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ajhhdgs7-ec6d-4b88-9b20-5322fb1d94e1");
        }
    }
}
