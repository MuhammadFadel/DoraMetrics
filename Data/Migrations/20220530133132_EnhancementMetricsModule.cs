using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class EnhancementMetricsModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MetricData");

            migrationBuilder.DropIndex(
                name: "IX_Metrics_GroupId",
                table: "Metrics");

            migrationBuilder.DropIndex(
                name: "IX_Metrics_ProjectId",
                table: "Metrics");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Metrics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MetricType",
                table: "Metrics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectType",
                table: "Metrics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Value",
                table: "Metrics",
                type: "float",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Metrics_GroupId",
                table: "Metrics",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Metrics_ProjectId",
                table: "Metrics",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Metrics_GroupId",
                table: "Metrics");

            migrationBuilder.DropIndex(
                name: "IX_Metrics_ProjectId",
                table: "Metrics");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Metrics");

            migrationBuilder.DropColumn(
                name: "MetricType",
                table: "Metrics");

            migrationBuilder.DropColumn(
                name: "ProjectType",
                table: "Metrics");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Metrics");

            migrationBuilder.CreateTable(
                name: "MetricData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangeFailureRateId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeploymentFrequencyId = table.Column<int>(type: "int", nullable: true),
                    LeadTimeForChangesId = table.Column<int>(type: "int", nullable: true),
                    TimeToRestoreServiceId = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetricData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetricData_Metrics_ChangeFailureRateId",
                        column: x => x.ChangeFailureRateId,
                        principalTable: "Metrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MetricData_Metrics_DeploymentFrequencyId",
                        column: x => x.DeploymentFrequencyId,
                        principalTable: "Metrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MetricData_Metrics_LeadTimeForChangesId",
                        column: x => x.LeadTimeForChangesId,
                        principalTable: "Metrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MetricData_Metrics_TimeToRestoreServiceId",
                        column: x => x.TimeToRestoreServiceId,
                        principalTable: "Metrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_MetricData_ChangeFailureRateId",
                table: "MetricData",
                column: "ChangeFailureRateId");

            migrationBuilder.CreateIndex(
                name: "IX_MetricData_DeploymentFrequencyId",
                table: "MetricData",
                column: "DeploymentFrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_MetricData_LeadTimeForChangesId",
                table: "MetricData",
                column: "LeadTimeForChangesId");

            migrationBuilder.CreateIndex(
                name: "IX_MetricData_TimeToRestoreServiceId",
                table: "MetricData",
                column: "TimeToRestoreServiceId");
        }
    }
}
