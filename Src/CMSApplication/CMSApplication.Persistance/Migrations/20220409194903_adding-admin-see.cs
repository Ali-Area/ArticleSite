using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMSApplication.Persistance.Migrations
{
    public partial class addingadminsee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "CreateDate", "SecurityStamp" },
                values: new object[] { "063aedd7-b3b7-4dac-a8d4-a263f359ceb1", new DateTime(2022, 4, 10, 0, 19, 3, 424, DateTimeKind.Local).AddTicks(4668), "7a917ab6-fa06-4310-bc62-ae8d80a726db" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "CreateDate", "SecurityStamp" },
                values: new object[] { "ea46d49d-212e-4d14-a6b2-9303f3e781d5", new DateTime(2022, 4, 10, 0, 14, 45, 768, DateTimeKind.Local).AddTicks(4110), "536fca56-2bf6-4eea-8713-1e7e0dd739a2" });
        }
    }
}
