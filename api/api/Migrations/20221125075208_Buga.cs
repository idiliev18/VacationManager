using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class Buga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "173d95c5-8bbd-4f5b-b2c8-9326b27180ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25875003-89ae-4da3-a5ba-f41d666f60c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ea34fe8-c743-403f-ba98-d62aa61ec0fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76efd3d7-a4f4-4ffe-a4a4-903d14c295db");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39d0bc99-84ba-472e-8a2c-39c2f69b0044", "9d9190a8-56c3-4afc-bf61-f1d21dfd588c", "CEO", "CEO" },
                    { "71ef4814-5def-4e9d-9419-c0b49e9f496e", "b0eb506e-87c0-4c15-b05c-424c4c31e630", "Unassigned", "UNASSIGNED" },
                    { "818ac76f-87ee-430c-b86a-49cd786374f2", "16565a04-e7fd-433c-af6d-dadd94641dfb", "Developer", "DEVELOPER" },
                    { "c92c856a-f17c-4d41-a104-8082d5f47c9b", "35637095-843d-42f7-89ec-4ef8fdb6bdc0", "Team Lead", "TEAM LEAD" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TeamId",
                table: "AspNetUsers",
                column: "TeamId");

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

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TeamId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39d0bc99-84ba-472e-8a2c-39c2f69b0044");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71ef4814-5def-4e9d-9419-c0b49e9f496e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "818ac76f-87ee-430c-b86a-49cd786374f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c92c856a-f17c-4d41-a104-8082d5f47c9b");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "173d95c5-8bbd-4f5b-b2c8-9326b27180ce", "fb479c2f-16ad-44c8-9678-b7c5ba1a1fec", "Team Lead", "TEAM LEAD" },
                    { "25875003-89ae-4da3-a5ba-f41d666f60c1", "2fa17a1d-0754-4096-8a36-a14a580578ab", "Unassigned", "UNASSIGNED" },
                    { "2ea34fe8-c743-403f-ba98-d62aa61ec0fd", "afd298dd-5e9b-485e-be05-26f5d4bca49d", "CEO", "CEO" },
                    { "76efd3d7-a4f4-4ffe-a4a4-903d14c295db", "8bb0f62d-9771-40e5-80b5-34ce89f2aad4", "Developer", "DEVELOPER" }
                });
        }
    }
}
