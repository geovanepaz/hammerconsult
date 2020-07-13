using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Evento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5ffb937a-871d-403c-a6de-d07d37bac951");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "acad0d2d-5838-45bb-872f-7914d1e343b4", 0, "1117e94c-55bf-450a-b6d3-cf56fbe647cb", "geovane@gmail.com", true, false, null, "GEOVANE@GMAIL.COM", "GEOVANE@GMAIL.COM", "AQAAAAEAACcQAAAAEI/PRZsDrMWJ/xGHy8bR6pJMJe1VmxqKTgs+ABQOOMW7yoPXe6e0XZGRsfI7bKcorg==", null, false, "db1d9f13-aa62-4bfd-815d-ccddff4f01e4", false, "geovane@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "acad0d2d-5838-45bb-872f-7914d1e343b4");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5ffb937a-871d-403c-a6de-d07d37bac951", 0, "1117e94c-55bf-450a-b6d3-cf56fbe647cb", "geovane@gmail.com", true, false, null, "GEOVANE@GMAIL.COM", "GEOVANE@GMAIL.COM", "AQAAAAEAACcQAAAAEI/PRZsDrMWJ/xGHy8bR6pJMJe1VmxqKTgs+ABQOOMW7yoPXe6e0XZGRsfI7bKcorg==", null, false, "db1d9f13-aa62-4bfd-815d-ccddff4f01e4", false, "geovane@gmail.com" });
        }
    }
}
