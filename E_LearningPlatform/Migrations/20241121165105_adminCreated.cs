using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_LearningPlatform.Migrations
{
    /// <inheritdoc />
    public partial class adminCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RegistrationDate", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ajhhdgs7-ec6d-4b88-9b20-5322fb1d94e1", 0, "83441b24-b260-47e7-a690-a5f7fc33df08", "admin@elearning.com", true, "Super", "Admin", false, null, "ADMIN@ELEARNING.COM", "SUPERADMIN", "AQAAAAIAAYagAAAAEN9SjHP4bEvrAFyL/lMYzPRJLPIugJy/qAu9dKOHSJ3SlKXoYRJuLg/QhNvMtzakMw==", "0634567891", false, new DateTime(2024, 11, 21, 16, 51, 4, 828, DateTimeKind.Utc).AddTicks(1906), "64798d2f-0e2b-4c2b-9427-4d5aa53e98e3", 1, false, "superadmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6ee2a5ea-ab9f-41a4-875e-fd4c1b142631", "ajhhdgs7-ec6d-4b88-9b20-5322fb1d94e1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6ee2a5ea-ab9f-41a4-875e-fd4c1b142631", "ajhhdgs7-ec6d-4b88-9b20-5322fb1d94e1" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ajhhdgs7-ec6d-4b88-9b20-5322fb1d94e1");
        }
    }
}
