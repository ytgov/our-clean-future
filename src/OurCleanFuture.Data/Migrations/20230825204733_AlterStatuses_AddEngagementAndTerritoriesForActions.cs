using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OurCleanFuture.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterStatuses_AddEngagementAndTerritoriesForActions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EngagementAndPartnershipActivities",
                table: "Actions",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                defaultValue: "")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ActionsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.CreateTable(
                name: "IndigenousGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndigenousGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActionIndigenousGroup",
                columns: table => new
                {
                    ActionsId = table.Column<int>(type: "int", nullable: false),
                    UndertakenInTraditionalTerritoriesOfId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionIndigenousGroup", x => new { x.ActionsId, x.UndertakenInTraditionalTerritoriesOfId });
                    table.ForeignKey(
                        name: "FK_ActionIndigenousGroup_Actions_ActionsId",
                        column: x => x.ActionsId,
                        principalTable: "Actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActionIndigenousGroup_IndigenousGroups_UndertakenInTraditionalTerritoriesOfId",
                        column: x => x.UndertakenInTraditionalTerritoriesOfId,
                        principalTable: "IndigenousGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionIndigenousGroup_UndertakenInTraditionalTerritoriesOfId",
                table: "ActionIndigenousGroup",
                column: "UndertakenInTraditionalTerritoriesOfId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionIndigenousGroup");

            migrationBuilder.DropTable(
                name: "IndigenousGroups");

            migrationBuilder.DropColumn(
                name: "EngagementAndPartnershipActivities",
                table: "Actions")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ActionsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");
        }
    }
}
