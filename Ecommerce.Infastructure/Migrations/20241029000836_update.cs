using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "72a22e4c-e658-4a52-9569-ebcad37d03b2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7755654e-75bf-456c-8bdb-1d18aac8d07f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7c345a92-c7e0-4580-8cd3-395f329baeb3", 0, "Idna", "e1fb611a-2d1e-4ded-a2cc-39568916f9c4", null, false, "ghada", "nofal", false, null, null, null, null, null, false, "99218e29-c9ef-4910-bd65-7111e8ac17ff", false, null },
                    { "8678c162-031a-4abe-8fce-a557df6c46d0", 0, "Idna", "f3e82b37-d08a-42c2-a33d-d8ef9160c8c1", null, false, "manal", "amro", false, null, null, null, null, null, false, "39cbe124-6733-4ad6-94f6-7b119298166f", false, null }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 10, 29, 2, 8, 31, 798, DateTimeKind.Local).AddTicks(7449));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 10, 29, 2, 8, 31, 798, DateTimeKind.Local).AddTicks(7533));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c345a92-c7e0-4580-8cd3-395f329baeb3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8678c162-031a-4abe-8fce-a557df6c46d0");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "72a22e4c-e658-4a52-9569-ebcad37d03b2", 0, "Idna", "b6a55c50-05d0-4293-bf90-d2d57090d79e", null, false, "ghada", "nofal", false, null, null, null, null, null, false, "e1cc8809-2c26-4882-b017-7565a0d38d89", false, null },
                    { "7755654e-75bf-456c-8bdb-1d18aac8d07f", 0, "Idna", "1772b7d3-2ba3-4e01-a1d0-675bcb211b3b", null, false, "manal", "amro", false, null, null, null, null, null, false, "83004377-dc18-4bb8-ad1a-a5c2f2991516", false, null }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 10, 29, 1, 57, 32, 470, DateTimeKind.Local).AddTicks(2465));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 10, 29, 1, 57, 32, 470, DateTimeKind.Local).AddTicks(2552));
        }
    }
}
