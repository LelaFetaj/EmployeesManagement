using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeManagementAPI.Migrations.Authentications
{
    /// <inheritdoc />
    public partial class PendingChangesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5aacec27-8bb0-48dc-bf8d-02ccbf581a61"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("be5e9ad3-b06e-42b4-b12f-c48a230e9ee4"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("79e81b16-749c-4b24-a152-6ecd1f99afdd"), "334302aa-c186-4536-9116-03c3264e6727", "Employee", "EMPLOYEE" },
                    { new Guid("a332e387-ae56-4e09-bbe3-2980ac685660"), "090fa0dc-bea7-42cb-bf6f-6964fea41ce1", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("5aacec27-8bb0-48dc-bf8d-02ccbf581a61"), "fdb90053-2f1d-4c7d-afc1-f0c45e6832d0", "Employee", "EMPLOYEE" },
                    { new Guid("be5e9ad3-b06e-42b4-b12f-c48a230e9ee4"), "c48e8d20-0b8c-48e1-9131-aab3f11f354e", "Admin", "ADMIN" }
                });
        }
    }
}
