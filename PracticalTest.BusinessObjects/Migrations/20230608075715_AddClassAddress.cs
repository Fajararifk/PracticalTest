using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticalTest.BusinessObjects.Migrations
{
    public partial class AddClassAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizers_SportsEvents_SportEventsId",
                table: "Organizers");

            migrationBuilder.DropIndex(
                name: "IX_Organizers_SportEventsId",
                table: "Organizers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ea7fdbb-1bcb-4551-917f-9a1d5e3c4e64");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9226899c-f4b5-4ce0-b291-f0ce465afdab");

            migrationBuilder.DropColumn(
                name: "SportEventsId",
                table: "Organizers");

            migrationBuilder.AddColumn<int>(
                name: "AddressAdId",
                table: "SportsEvents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "organizerId",
                table: "SportsEvents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdStreetFr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdBuilding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdPostalCode = table.Column<int>(type: "int", nullable: true),
                    AdCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdUrbisRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdIsUrbirsAddress = table.Column<bool>(type: "bit", nullable: true),
                    AdStreetNl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdStreetEn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AdId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1734b295-caaa-410d-b44e-b2ccb1cc0b90", "6e79438f-faa8-4a76-9091-3b36b308d72a", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d286506b-b2e0-4bf3-8eb1-9850b9fd9cbd", "40950a0c-0a86-407c-9d43-cede0a62543d", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_SportsEvents_AddressAdId",
                table: "SportsEvents",
                column: "AddressAdId");

            migrationBuilder.CreateIndex(
                name: "IX_SportsEvents_organizerId",
                table: "SportsEvents",
                column: "organizerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SportsEvents_Addresses_AddressAdId",
                table: "SportsEvents",
                column: "AddressAdId",
                principalTable: "Addresses",
                principalColumn: "AdId");

            migrationBuilder.AddForeignKey(
                name: "FK_SportsEvents_Organizers_organizerId",
                table: "SportsEvents",
                column: "organizerId",
                principalTable: "Organizers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportsEvents_Addresses_AddressAdId",
                table: "SportsEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_SportsEvents_Organizers_organizerId",
                table: "SportsEvents");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_SportsEvents_AddressAdId",
                table: "SportsEvents");

            migrationBuilder.DropIndex(
                name: "IX_SportsEvents_organizerId",
                table: "SportsEvents");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1734b295-caaa-410d-b44e-b2ccb1cc0b90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d286506b-b2e0-4bf3-8eb1-9850b9fd9cbd");

            migrationBuilder.DropColumn(
                name: "AddressAdId",
                table: "SportsEvents");

            migrationBuilder.DropColumn(
                name: "organizerId",
                table: "SportsEvents");

            migrationBuilder.AddColumn<int>(
                name: "SportEventsId",
                table: "Organizers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6ea7fdbb-1bcb-4551-917f-9a1d5e3c4e64", "4d3c83f7-32c9-4fc0-9465-d7dd4e13395b", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9226899c-f4b5-4ce0-b291-f0ce465afdab", "253bea74-13f9-47fb-9800-8412616f6270", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Organizers_SportEventsId",
                table: "Organizers",
                column: "SportEventsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizers_SportsEvents_SportEventsId",
                table: "Organizers",
                column: "SportEventsId",
                principalTable: "SportsEvents",
                principalColumn: "Id");
        }
    }
}
