using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeManagementAPI.Migrations.Authentications
{
    /// <inheritdoc />
    public partial class UpdateSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("79e81b16-749c-4b24-a152-6ecd1f99afdd"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a332e387-ae56-4e09-bbe3-2980ac685660"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("4e467a75-cef8-4467-bc38-4e1e5eb1138d"), "adbbada9-b216-44dc-bcb0-6c5db0e6f6eb", "Employee", "EMPLOYEE" },
                    { new Guid("70fb5ca5-a446-4c1e-acc4-6344bc518e08"), "74fee039-4802-4150-869b-82a9cdd01e62", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("79e81b16-749c-4b24-a152-6ecd1f99afdd"), "334302aa-c186-4536-9116-03c3264e6727", "Employee", "EMPLOYEE" },
                    { new Guid("a332e387-ae56-4e09-bbe3-2980ac685660"), "090fa0dc-bea7-42cb-bf6f-6964fea41ce1", "Admin", "ADMIN" }
                });
        }
    }
}
