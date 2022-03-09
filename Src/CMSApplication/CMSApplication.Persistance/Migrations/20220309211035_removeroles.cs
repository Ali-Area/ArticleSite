using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMSApplication.Persistance.Migrations
{
    public partial class removeroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "AdminUser");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "UserId" },
                values: new object[] { "194c9b05-6824-4fea-8223-61393c1dbbc7", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user",
                column: "ConcurrencyStamp",
                value: "7743ae81-3f25-440e-bef3-d80fb7b23c6f");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user",
                column: "ConcurrencyStamp",
                value: "5f178cb4-5ecc-4dac-9768-4fdc3fa9bc88");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "AdminUser", 0, "b5e86dea-7299-4210-93e9-6acc95297d6d", "ali7139.r@gmail.com", false, false, false, null, "Admin", "ALI7139.R@GMAIL.COM", null, "AQAAAAEAACcQAAAAENeY1tAu4a0wGl0F7dOT+4LUgiXhv5NsQdB8V+5ua5RTnl75o+TAvO3JRgoWe3wPXQ==", null, false, "admin", "b809446c-68e1-4db6-9144-577dcf183069", false, "ali7139.r@gmail.com" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                columns: new[] { "ConcurrencyStamp", "UserId" },
                values: new object[] { "1b5e056c-181d-487a-9a3d-fedf322d3b35", "AdminUser" });
        }
    }
}
