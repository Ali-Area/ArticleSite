using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMSApplication.Persistance.Migrations
{
    public partial class adding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "CreateDate", "EmailConfirmed", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7a8a161-47c2-4c3e-a7b5-17935409a7a1", new DateTime(2022, 4, 10, 0, 40, 8, 440, DateTimeKind.Local).AddTicks(8110), true, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEGYwr8XwqFVQ6XezUBYMe4vMGzuuEHjv40khz306SrKRVpw25bzFPVkTCslnCqTSmw==", "68d0e4eb-8b72-40a9-bbb6-365acceff7aa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "18def546-cdbb-44f5-b317-2d3276dcdebe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user",
                column: "ConcurrencyStamp",
                value: "eee9e999-8253-4e22-a480-e3d7b469c783");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminuser",
                columns: new[] { "ConcurrencyStamp", "CreateDate", "EmailConfirmed", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ad1319a-7a1d-41ca-8a63-e90c401b7af6", new DateTime(2022, 4, 10, 0, 32, 7, 355, DateTimeKind.Local).AddTicks(2897), false, null, null, "AQAAAAEAACcQAAAAEHsPNaL+ZMa+oTrmQo7vVt8PvdUs2pqRVXRBshPuCRCx92CewHhmDX6lFMgP/XRP0w==", "12653aff-bd4c-4b6d-b66c-200f4e70abdd" });
        }
    }
}
