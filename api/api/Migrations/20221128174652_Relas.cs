using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class Relas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0553f10f-0ee8-4bb0-b2d1-152b0d2ed4e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "176db17b-3f49-40c8-9812-f0d7d2fb17e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2427a4b5-1857-4773-9d68-26158f6ea292");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61561b42-7070-4cef-844e-a9dbcc53f798");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Project",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5a193a0a-a69c-4e3a-84c5-3a3a3515567a", "56ca4e47-438d-4385-93ed-06b4601d2551", "Developer", "DEVELOPER" },
                    { "6deb4c1a-d662-4b09-84b3-47fef3bd7a91", "6717e29f-1d0d-433f-b338-a5a2651a37aa", "Unassigned", "UNASSIGNED" },
                    { "9de0d091-aae1-41cb-9aa6-f5fdcfead523", "eb0c0a09-da96-4c2a-968d-205d696e782f", "Team Lead", "TEAM LEAD" },
                    { "bd3a9e27-2bdf-4a65-a0e0-0b1f61abd21e", "1b3936ef-507f-4135-b684-9368c3f6095f", "CEO", "CEO" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a193a0a-a69c-4e3a-84c5-3a3a3515567a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6deb4c1a-d662-4b09-84b3-47fef3bd7a91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9de0d091-aae1-41cb-9aa6-f5fdcfead523");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd3a9e27-2bdf-4a65-a0e0-0b1f61abd21e");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0553f10f-0ee8-4bb0-b2d1-152b0d2ed4e8", "f79bc62c-a3bb-4231-8d06-fe3e060e11dd", "Team Lead", "TEAM LEAD" },
                    { "176db17b-3f49-40c8-9812-f0d7d2fb17e8", "9e413f66-2309-44a6-b3b3-f74648ae95de", "Developer", "DEVELOPER" },
                    { "2427a4b5-1857-4773-9d68-26158f6ea292", "72ecbaeb-9942-4a01-b23f-1af1acf338fc", "Unassigned", "UNASSIGNED" },
                    { "61561b42-7070-4cef-844e-a9dbcc53f798", "e85208c4-c735-45df-bc50-be8c7b04b1f8", "CEO", "CEO" }
                });
        }
    }
}
