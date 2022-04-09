using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMSApplication.Persistance.Migrations
{
    public partial class addi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "bf756cf6-bf99-45e1-b4ab-61b4e27a7643");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user",
                column: "ConcurrencyStamp",
                value: "8a39059b-51f6-47bd-b973-55191ac7e508");

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "UserName", "admin@admin.com", "adminuser" },
                    { 2, "Email", "admin@admin.com", "adminuser" },
                    { 3, "UserId", "adminuser", "adminuser" },
                    { 4, "Name", "MainAdmin", "adminuser" },
                    { 5, "Role", "Admin", "adminuser" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminuser",
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3fd17d61-8e0e-4fd3-b4c8-39171aeb2dcd", new DateTime(2022, 4, 10, 0, 55, 17, 878, DateTimeKind.Local).AddTicks(4988), "AQAAAAEAACcQAAAAEHl3p97efbMYt/Q9vkkMNvVZDAlDiUY8BKUKM+45hH/YEO5AjNN3WRWr7EoNqKct/w==", "6bd73ab7-a2c2-441b-a89c-540e0a12f98d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 5);

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
    }
}
