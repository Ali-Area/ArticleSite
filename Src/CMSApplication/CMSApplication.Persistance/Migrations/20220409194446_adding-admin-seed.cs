using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMSApplication.Persistance.Migrations
{
    public partial class addingadminseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "90be1920-830d-4946-972a-90378f584fd0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user",
                column: "ConcurrencyStamp",
                value: "b86af95a-f608-493c-8192-d4bad91cabe1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminuser",
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea46d49d-212e-4d14-a6b2-9303f3e781d5", new DateTime(2022, 4, 10, 0, 14, 45, 768, DateTimeKind.Local).AddTicks(4110), "AQAAAAEAACcQAAAAEFA8oy7rABbSfvqo4+g7j2QcNhSvDr8oXX++3W50kfBys4Dvrrbaz2tCtTTX5iupYA==", "536fca56-2bf6-4eea-8713-1e7e0dd739a2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "042b632e-c393-426c-90a4-9d00990dec7b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user",
                column: "ConcurrencyStamp",
                value: "7c859025-6ed3-4448-a2fe-9ef9b21f5aa9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminuser",
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04b9a5d0-70db-4054-9cc6-b3f9654775c7", new DateTime(2022, 4, 9, 19, 45, 20, 405, DateTimeKind.Local).AddTicks(459), null, "a12aa4a3-274c-47be-b28d-eba1f7ba9f95" });
        }
    }
}
