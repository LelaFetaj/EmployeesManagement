using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeManagementAPI.Migrations.Authentications
{
    /// <inheritdoc />
    public partial class FixPendingChangesWarningConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4e467a75-cef8-4467-bc38-4e1e5eb1138d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("70fb5ca5-a446-4c1e-acc4-6344bc518e08"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("394c210d-808d-43fd-91cc-aa1f61f8581a"), "df3364e4-74fe-48c0-a90b-2666bceb7d46", "Employee", "EMPLOYEE" },
                    { new Guid("94654d36-9597-41ab-bec6-369a3604b0a3"), "9a391c93-65d3-4b00-be41-9fcad7355345", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("394c210d-808d-43fd-91cc-aa1f61f8581a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("94654d36-9597-41ab-bec6-369a3604b0a3"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("4e467a75-cef8-4467-bc38-4e1e5eb1138d"), "adbbada9-b216-44dc-bcb0-6c5db0e6f6eb", "Employee", "EMPLOYEE" },
                    { new Guid("70fb5ca5-a446-4c1e-acc4-6344bc518e08"), "74fee039-4802-4150-869b-82a9cdd01e62", "Admin", "ADMIN" }
                });
        }
    }
}
