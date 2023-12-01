using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticalTest.BusinessObjects.Migrations
{
    public partial class addCreatedAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1734b295-caaa-410d-b44e-b2ccb1cc0b90");
                
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d286506b-b2e0-4bf3-8eb1-9850b9fd9cbd");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "18a8daef-0251-4589-9658-8c5529d2bd3d", "d3c651c3-5738-4ba3-8f97-552169d91558", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "44baedb1-bbaf-42a4-b554-4ddac2d3d002", "9f280250-37a5-4bd8-a747-fb11c4fdb303", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18a8daef-0251-4589-9658-8c5529d2bd3d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44baedb1-bbaf-42a4-b554-4ddac2d3d002");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1734b295-caaa-410d-b44e-b2ccb1cc0b90", "6e79438f-faa8-4a76-9091-3b36b308d72a", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d286506b-b2e0-4bf3-8eb1-9850b9fd9cbd", "40950a0c-0a86-407c-9d43-cede0a62543d", "Admin", "ADMIN" });
        }
    }
}
