using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMSApplication.Persistance.Migrations
{
    public partial class addin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "47bf863b-3bc8-4a40-8644-a14a323264bc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user",
                column: "ConcurrencyStamp",
                value: "6d9a7edb-c1bd-49b6-af37-3b7e8a277776");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminuser",
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ade6173-d59c-4150-9dcb-1e95d0e417fb", new DateTime(2022, 4, 10, 0, 43, 24, 906, DateTimeKind.Local).AddTicks(1229), "AQAAAAEAACcQAAAAENkZgwTtndCp3FIEadPZEnUPOVyTRoz+coi/i4UNZ+gjykfJw2UQ4xHVztTHdSaPbw==", "bd49af98-1608-49e3-99b5-a068a0be61d7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "90b72bd6-e8ed-469a-8e45-742f0bd100da");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user",
                column: "ConcurrencyStamp",
                value: "327b8dec-420e-4405-bebb-35b2129a40dd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminuser",
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7a8a161-47c2-4c3e-a7b5-17935409a7a1", new DateTime(2022, 4, 10, 0, 40, 8, 440, DateTimeKind.Local).AddTicks(8110), "AQAAAAEAACcQAAAAEGYwr8XwqFVQ6XezUBYMe4vMGzuuEHjv40khz306SrKRVpw25bzFPVkTCslnCqTSmw==", "68d0e4eb-8b72-40a9-bbb6-365acceff7aa" });
        }
    }
}
