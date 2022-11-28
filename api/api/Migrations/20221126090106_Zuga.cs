using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class Zuga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "230ac495-7fc1-4b34-9729-8cdfeba1bf17", "48ac43f3-3387-41f0-8757-a7b0e89461c8", "Team Lead", "TEAM LEAD" },
                    { "2bc78b26-96f5-4587-9195-c1eff4ed5e22", "8ebb5473-6a81-41d3-8411-7d74592ceec0", "CEO", "CEO" },
                    { "cff06751-4e0f-4a3e-9bbc-5635a9a5acb6", "d5b3fc40-bbfa-4c25-94bb-f432c20b225a", "Developer", "DEVELOPER" },
                    { "fe3e2f9f-5115-4b2c-98ad-8c81d117140c", "1fc62826-a79d-4304-a858-21a8310993d2", "Unassigned", "UNASSIGNED" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "230ac495-7fc1-4b34-9729-8cdfeba1bf17");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2bc78b26-96f5-4587-9195-c1eff4ed5e22");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cff06751-4e0f-4a3e-9bbc-5635a9a5acb6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe3e2f9f-5115-4b2c-98ad-8c81d117140c");

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
        }
    }
}
