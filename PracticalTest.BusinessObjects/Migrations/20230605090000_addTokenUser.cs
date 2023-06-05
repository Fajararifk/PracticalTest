using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticalTest.BusinessObjects.Migrations
{
    public partial class addTokenUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "199aedb9-fb16-4d45-b95d-90ba70bd370b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e33ffe80-1865-4d3b-8c16-6f4736f21c50");

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6ea7fdbb-1bcb-4551-917f-9a1d5e3c4e64", "4d3c83f7-32c9-4fc0-9465-d7dd4e13395b", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9226899c-f4b5-4ce0-b291-f0ce465afdab", "253bea74-13f9-47fb-9800-8412616f6270", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ea7fdbb-1bcb-4551-917f-9a1d5e3c4e64");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9226899c-f4b5-4ce0-b291-f0ce465afdab");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "199aedb9-fb16-4d45-b95d-90ba70bd370b", "69d52fa8-ff67-4bb5-84c6-f4b684cbed75", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e33ffe80-1865-4d3b-8c16-6f4736f21c50", "1c9dde79-f7b0-46e2-b79e-d8dc43ecae6a", "Admin", "ADMIN" });
        }
    }
}
