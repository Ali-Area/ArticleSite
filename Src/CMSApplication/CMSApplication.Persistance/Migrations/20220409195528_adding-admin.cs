using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMSApplication.Persistance.Migrations
{
    public partial class addingadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "1c4cafbe-57dc-4c27-bed5-397cd207df7c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user",
                column: "ConcurrencyStamp",
                value: "09aeb776-6c45-43b6-b8e7-8b99937b2392");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminuser",
                columns: new[] { "ConcurrencyStamp", "CreateDate", "SecurityStamp" },
                values: new object[] { "065b17e4-9e45-4f8e-aa5b-65262d0939eb", new DateTime(2022, 4, 10, 0, 25, 27, 865, DateTimeKind.Local).AddTicks(7796), "3ea9efe6-0035-4a95-84a4-a1148c457c5b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "e65f3438-fbb1-405f-ab5b-9313c0723dc9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user",
                column: "ConcurrencyStamp",
                value: "f9a6ce5d-8b46-47ac-a1e9-bc5a96a435a6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminuser",
                columns: new[] { "ConcurrencyStamp", "CreateDate", "SecurityStamp" },
                values: new object[] { "528c1984-9bf2-442b-93c8-c9ca42b77d00", new DateTime(2022, 4, 10, 0, 22, 9, 454, DateTimeKind.Local).AddTicks(9295), "75c5b14f-f99c-4b56-b24c-a75c8268aab5" });
        }
    }
}
