using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMSApplication.Persistance.Migrations
{
    public partial class addingadmi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84de2396-014b-4ac8-86d3-364c95905ed9", new DateTime(2022, 4, 10, 0, 28, 8, 126, DateTimeKind.Local).AddTicks(1117), "AQAAAAEAACcQAAAAEP8gsZPPUVE5Fq9IAEafiv+hM7oTtnnGUX61JDrScPrcuW16lb+nGXQ9KslsUUpg4g==", "c18f1063-c640-4ba7-8ab4-a62a83706ea3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "065b17e4-9e45-4f8e-aa5b-65262d0939eb", new DateTime(2022, 4, 10, 0, 25, 27, 865, DateTimeKind.Local).AddTicks(7796), "AQAAAAEAACcQAAAAEOKgG4mmXYKPezfIMmvahZYxGgicQNyNbx3mto8RqVg3EYqzx5IFwvITe0Whytl7rg==", "3ea9efe6-0035-4a95-84a4-a1148c457c5b" });
        }
    }
}
