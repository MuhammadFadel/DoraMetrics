using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addMetricsToGroupLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Metrics_Projects_ProjectId",
                table: "Metrics");

            migrationBuilder.DropIndex(
                name: "IX_Metrics_ProjectId",
                table: "Metrics");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Metrics",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Metrics",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Metrics_GroupId",
                table: "Metrics",
                column: "GroupId",
                unique: true,
                filter: "[GroupId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Metrics_ProjectId",
                table: "Metrics",
                column: "ProjectId",
                unique: true,
                filter: "[ProjectId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Metrics_Groups_GroupId",
                table: "Metrics",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Metrics_Projects_ProjectId",
                table: "Metrics",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Metrics_Groups_GroupId",
                table: "Metrics");

            migrationBuilder.DropForeignKey(
                name: "FK_Metrics_Projects_ProjectId",
                table: "Metrics");

            migrationBuilder.DropIndex(
                name: "IX_Metrics_GroupId",
                table: "Metrics");

            migrationBuilder.DropIndex(
                name: "IX_Metrics_ProjectId",
                table: "Metrics");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Metrics");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Metrics",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Metrics_ProjectId",
                table: "Metrics",
                column: "ProjectId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Metrics_Projects_ProjectId",
                table: "Metrics",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
