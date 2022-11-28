using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    public partial class Duga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectsTeams",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsTeams", x => new { x.ProjectId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_ProjectsTeams_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectsTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsTeams_TeamId",
                table: "ProjectsTeams",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectsTeams");

            migrationBuilder.DropTable(
                name: "Project");

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
    }
}
