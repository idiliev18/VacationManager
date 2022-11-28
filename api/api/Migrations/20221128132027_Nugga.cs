using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class Nugga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "389f120b-c5d8-4d30-80ba-8e460ad5970c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bb836ac-195d-4ade-aadc-6b4d1078f7d7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d34d655-4331-4a62-b39e-5d1f824dde4c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8f3c5e9-707e-4813-8bf2-cd1ff1fd3637");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "389f120b-c5d8-4d30-80ba-8e460ad5970c", "f3bd6f74-800f-42cc-b0c1-74f18d1cd43c", "Team Lead", "TEAM LEAD" },
                    { "3bb836ac-195d-4ade-aadc-6b4d1078f7d7", "e11ed2dd-28ad-4b83-bd69-3db02610ca42", "Developer", "DEVELOPER" },
                    { "4d34d655-4331-4a62-b39e-5d1f824dde4c", "424280e8-1b16-4c06-b349-558d37cce409", "CEO", "CEO" },
                    { "a8f3c5e9-707e-4813-8bf2-cd1ff1fd3637", "d68a72c3-ac79-4fbf-afa3-99047df8c592", "Unassigned", "UNASSIGNED" }
                });
        }
    }
}
