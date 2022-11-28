using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class Nugga1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Teams_TeamId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67f60b80-7ea4-42fb-ad28-229b6b28886a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "737384d1-916e-4b47-9055-3da1efb8f374");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9658b8f8-cedf-48ae-821a-b06836bc17e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3f74338-53ae-4a22-b474-be05812973ee");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4b40b007-b1ca-4012-aaf5-89bf0ca83abc", "801ae394-bf8b-46bc-91d7-54f4e6aae345", "CEO", "CEO" },
                    { "512ebdbb-91bd-4470-b80f-de196264c1bd", "4c6e0795-b584-4c37-8f1b-d2c566a2ba8b", "Team Lead", "TEAM LEAD" },
                    { "7abdb2ea-df1d-48e5-b3f6-3acdfdf90ae6", "3ae7f647-55dd-4403-8a29-655d21455ddc", "Developer", "DEVELOPER" },
                    { "8087a458-761e-4489-8a33-617082be2591", "1c1eac2d-86ef-4e4f-8e2c-7341538f186d", "Unassigned", "UNASSIGNED" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Teams_TeamId",
                table: "AspNetUsers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Teams_TeamId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b40b007-b1ca-4012-aaf5-89bf0ca83abc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "512ebdbb-91bd-4470-b80f-de196264c1bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7abdb2ea-df1d-48e5-b3f6-3acdfdf90ae6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8087a458-761e-4489-8a33-617082be2591");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "67f60b80-7ea4-42fb-ad28-229b6b28886a", "c2b7cf4b-72b0-4631-8300-99b34485380c", "Unassigned", "UNASSIGNED" },
                    { "737384d1-916e-4b47-9055-3da1efb8f374", "1abbf255-5065-4065-90b8-8da763242dad", "Developer", "DEVELOPER" },
                    { "9658b8f8-cedf-48ae-821a-b06836bc17e5", "72313fd5-13cd-4560-b58d-4cc7489557f4", "Team Lead", "TEAM LEAD" },
                    { "f3f74338-53ae-4a22-b474-be05812973ee", "05954e28-b865-4b7f-b951-260c4784809f", "CEO", "CEO" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Teams_TeamId",
                table: "AspNetUsers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
