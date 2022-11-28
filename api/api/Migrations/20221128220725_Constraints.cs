using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class Constraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "Teams",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Project",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Project",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(32)",
                maxLength: 32,
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
                    { "19e2a61d-10b0-4bfc-bbae-59bf17c4f8d0", "b3db8470-9311-407f-9692-8f535daa924d", "Developer", "DEVELOPER" },
                    { "bb060d3e-e647-4244-a947-b70d97f5ac7f", "a5b735db-1b21-4ea1-a004-d069c534e42f", "Unassigned", "UNASSIGNED" },
                    { "bfbce91a-d709-4130-a78a-d55ce8cc294c", "ee12d07b-5774-4382-8b93-9edfc22c4587", "Team Lead", "TEAM LEAD" },
                    { "d1b2a1c9-6fdb-41c8-834b-70ade8221c1d", "9219b37e-cc0a-4105-93bd-3ef40936a975", "CEO", "CEO" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19e2a61d-10b0-4bfc-bbae-59bf17c4f8d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb060d3e-e647-4244-a947-b70d97f5ac7f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfbce91a-d709-4130-a78a-d55ce8cc294c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1b2a1c9-6fdb-41c8-834b-70ade8221c1d");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Project",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

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
    }
}
