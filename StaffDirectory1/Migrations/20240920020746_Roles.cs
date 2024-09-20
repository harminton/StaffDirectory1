using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StaffDirectory1.Migrations
{
    public partial class Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DropColumn(
                name: "LoginProvider",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProviderKey",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "8a5fdc7d-79d5-426e-9778-c6d9bc64a6df");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "91ea826f-9c4f-414c-b4a3-f9013cc6a17e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "f554c39d-790a-437b-9512-820f41811cca");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "46423cfe-0414-4309-9cb2-daac4025fcad", "ac150559@avcol.school.nz", true, "harminton", "Vasquez", false, null, "AC150559@AVCOL.SCHOOL.NZ", "HARMINTON", "AQAAAAEAACcQAAAAEEKL4O7nMB/tG52E16wQG3R66pyZe88YDJ0E+ECvBWTcwbISHiqMvMZechRMs0SkFw==", null, false, "02ebca4a-968d-4485-bc7d-f6e0d39da568", false, null },
                    { "2", 0, "fc2d85c7-9245-4c84-9853-d1474651c6ff", "staff@example.com", true, "staff", "Member", false, null, "STAFF@EXAMPLE.COM", "STAFF@EXAMPLE.COM", "AQAAAAEAACcQAAAAEDa5WuxN36rIwFjf1ggRgi6ToybsedWCmKLyCQxmWAN39dlwCrSKtPp+h1TsdTQMCA==", null, false, "dc1c10f5-ff50-4426-97d4-aac1e7f0de03", false, null },
                    { "3", 0, "e5f88eef-0c37-4650-a252-e2e5e3f09be8", "Student@example.com", true, "Student", "Member", false, null, "STUDENT@EXAMPLE.COM", "STUDENT@EXAMPLE.COM", "AQAAAAEAACcQAAAAECz2/lrdZtqJygqx9QN5V1ZmjgTh3hc+VQ2Q6S3NtT//toeAQX1uIjL+b7msOD0UrA==", null, false, "004709ee-26b5-4b6e-89b1-b1049179adab", false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3", "3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "3" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.AddColumn<string>(
                name: "LoginProvider",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProviderKey",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "3957cb29-ecaf-4b6b-a030-c3836073f8d4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "fff36d8d-6274-41dd-a082-6f9bf3a02407");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "724be610-1d22-44b7-870b-6328e79de5ac");

            migrationBuilder.InsertData(
                table: "IdentityUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "67c52774-34a4-4c1b-a231-fb015c8a7912", "ac150559@avcol.school.nz", true, false, null, "AC150559@AVCOL.SCHOOL.NZ", "HARMINTON", "AQAAAAEAACcQAAAAENpOC1aG1qYw4fagXers3bZ9oF79j2LOtGGeGRURfofG+JjKEbpCj07Ac4OR9nPAbQ==", null, false, "d741dd36-a313-4251-88c1-6f948badf6bd", false, "harminton" },
                    { "2", 0, "ca09b7bf-c0b9-481c-a1a6-6f6737c3a6ee", "staff@example.com", true, false, null, "STAFF@EXAMPLE.COM", "STAFF@EXAMPLE.COM", "AQAAAAEAACcQAAAAEDv/27rC/TffxWdrXYs7t4418fZrgXyw8WiSikRbpBT16H1Z9V+YwfNTtPLR9uFMOw==", null, false, "09760c31-4baa-4556-a390-ec0bd7ccceb2", false, "staff@example.com" },
                    { "3", 0, "a31527b8-e465-475f-9ee4-952f67e5bcc7", "Student@example.com", true, false, null, "STUDENT@EXAMPLE.COM", "STUDENT@EXAMPLE.COM", "AQAAAAEAACcQAAAAEBWJRn7ZbjHTdKoMFytgL9HFqpae8dab+jmN+p6iDrioynCzZ2R5e4l8W5+5GHtfWA==", null, false, "47b49e28-69d3-430d-b297-ad29c449f263", false, "Student" }
                });
        }
    }
}
