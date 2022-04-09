using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMSApplication.Persistance.Migrations
{
    public partial class addingadminse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "528c1984-9bf2-442b-93c8-c9ca42b77d00", new DateTime(2022, 4, 10, 0, 22, 9, 454, DateTimeKind.Local).AddTicks(9295), "AQAAAAEAACcQAAAAEOKgG4mmXYKPezfIMmvahZYxGgicQNyNbx3mto8RqVg3EYqzx5IFwvITe0Whytl7rg==", "75c5b14f-f99c-4b56-b24c-a75c8268aab5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "dd02400c-e1a2-497f-a8fd-82b40cadb51e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user",
                column: "ConcurrencyStamp",
                value: "b5164d53-a2ff-4130-8cd9-ca85d9c2d4fa");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminuser",
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "063aedd7-b3b7-4dac-a8d4-a263f359ceb1", new DateTime(2022, 4, 10, 0, 19, 3, 424, DateTimeKind.Local).AddTicks(4668), "AQAAAAEAACcQAAAAEFA8oy7rABbSfvqo4+g7j2QcNhSvDr8oXX++3W50kfBys4Dvrrbaz2tCtTTX5iupYA==", "7a917ab6-fa06-4310-bc62-ae8d80a726db" });
        }
    }
}
