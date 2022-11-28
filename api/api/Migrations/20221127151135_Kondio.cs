using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class Kondio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Teams_TeamId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87e5349f-e49e-4cc6-8100-b65eb344b1ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9242ca05-276a-4623-8d0a-c6dd7e8d437d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc840fa2-6f17-4b75-88b7-0df0fa123dde");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e60ee28a-5ab2-44d9-8921-df577e529025");

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
                    { "389f120b-c5d8-4d30-80ba-8e460ad5970c", "f3bd6f74-800f-42cc-b0c1-74f18d1cd43c", "Team Lead", "TEAM LEAD" },
                    { "3bb836ac-195d-4ade-aadc-6b4d1078f7d7", "e11ed2dd-28ad-4b83-bd69-3db02610ca42", "Developer", "DEVELOPER" },
                    { "4d34d655-4331-4a62-b39e-5d1f824dde4c", "424280e8-1b16-4c06-b349-558d37cce409", "CEO", "CEO" },
                    { "a8f3c5e9-707e-4813-8bf2-cd1ff1fd3637", "d68a72c3-ac79-4fbf-afa3-99047df8c592", "Unassigned", "UNASSIGNED" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Teams_TeamId",
                table: "AspNetUsers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Teams_TeamId",
                table: "AspNetUsers");

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
                    { "87e5349f-e49e-4cc6-8100-b65eb344b1ad", "87b60fbf-9e95-4730-a59a-501260cbf493", "Unassigned", "UNASSIGNED" },
                    { "9242ca05-276a-4623-8d0a-c6dd7e8d437d", "80e88212-b87f-4dde-98ca-bd58bc76b913", "Team Lead", "TEAM LEAD" },
                    { "bc840fa2-6f17-4b75-88b7-0df0fa123dde", "7ce830e6-ea6c-494d-a3f7-86df59519dbf", "Developer", "DEVELOPER" },
                    { "e60ee28a-5ab2-44d9-8921-df577e529025", "4d92423f-ae23-43b8-a73d-a11124a99695", "CEO", "CEO" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Teams_TeamId",
                table: "AspNetUsers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }
    }
}
