using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddGroupLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Visibility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShareWithGroupLock = table.Column<bool>(type: "bit", nullable: false),
                    RequireTwoFactorAuthentication = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorGracePeriod = table.Column<int>(type: "int", nullable: false),
                    ProjectCreationLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubgroupCreationLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LfsEnabled = table.Column<bool>(type: "bit", nullable: false),
                    DefaultBranchProtection = table.Column<int>(type: "int", nullable: false),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestAccessEnabled = table.Column<bool>(type: "bit", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileTemplateProjectId = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_GroupId",
                table: "Projects",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Groups_GroupId",
                table: "Projects",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Groups_GroupId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Projects_GroupId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Projects");
        }
    }
}
