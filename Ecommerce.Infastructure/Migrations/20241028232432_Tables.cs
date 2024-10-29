using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "01fab3c9-a8df-4467-a406-8036153318ad");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1c639919-b2ce-4bd1-8558-0f0869225629");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "15a5e779-ba14-4619-8345-fda9c47ddee9", 0, "Idna", "0533de66-1c1e-4dbc-8bb1-b63bd91370c1", null, false, "manal", "amro", false, null, null, null, null, null, false, "ba3fed24-8bdb-49fa-8f23-6063010861ea", false, null },
                    { "55e26ec1-98e3-49c7-80eb-bee0b18917f7", 0, "Idna", "f6e7899b-b9d4-46c2-b5d8-f29608c62aab", null, false, "ghada", "nofal", false, null, null, null, null, null, false, "fe45468f-89bf-4fc2-b263-8d18a83ae06f", false, null }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 10, 29, 1, 24, 28, 989, DateTimeKind.Local).AddTicks(3698));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 10, 29, 1, 24, 28, 989, DateTimeKind.Local).AddTicks(3781));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "15a5e779-ba14-4619-8345-fda9c47ddee9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55e26ec1-98e3-49c7-80eb-bee0b18917f7");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "01fab3c9-a8df-4467-a406-8036153318ad", 0, "Idna", "f1c7715f-d5c4-4225-948d-a6b290126cb1", null, false, "manal", "amro", false, null, null, null, null, null, false, "3d4b0206-00b0-4853-9d1a-31d9957d9a3f", false, null },
                    { "1c639919-b2ce-4bd1-8558-0f0869225629", 0, "Idna", "5ed5ef78-42a3-4d53-b209-067757a280b9", null, false, "ghada", "nofal", false, null, null, null, null, null, false, "909d3295-c063-4537-b576-735954b383e9", false, null }
                });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 7, 25, 15, 0, 48, 67, DateTimeKind.Local).AddTicks(2990));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 7, 25, 15, 0, 48, 67, DateTimeKind.Local).AddTicks(3078));
        }
    }
}
