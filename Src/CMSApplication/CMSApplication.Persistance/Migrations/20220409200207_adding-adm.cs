using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMSApplication.Persistance.Migrations
{
    public partial class addingadm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "8ad1319a-7a1d-41ca-8a63-e90c401b7af6", new DateTime(2022, 4, 10, 0, 32, 7, 355, DateTimeKind.Local).AddTicks(2897), "AQAAAAEAACcQAAAAEHsPNaL+ZMa+oTrmQo7vVt8PvdUs2pqRVXRBshPuCRCx92CewHhmDX6lFMgP/XRP0w==", "12653aff-bd4c-4b6d-b66c-200f4e70abdd", "admin@admin.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "313858db-7ea4-419c-b487-8a225cbf5583");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user",
                column: "ConcurrencyStamp",
                value: "88c55531-4458-41e5-a6e3-bdd621733db1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminuser",
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "84de2396-014b-4ac8-86d3-364c95905ed9", new DateTime(2022, 4, 10, 0, 28, 8, 126, DateTimeKind.Local).AddTicks(1117), "AQAAAAEAACcQAAAAEP8gsZPPUVE5Fq9IAEafiv+hM7oTtnnGUX61JDrScPrcuW16lb+nGXQ9KslsUUpg4g==", "c18f1063-c640-4ba7-8ab4-a62a83706ea3", "admin" });
        }
    }
}
