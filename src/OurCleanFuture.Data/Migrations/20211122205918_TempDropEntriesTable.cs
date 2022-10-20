using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OurCleanFuture.Data.Migrations
{
    public partial class TempDropEntriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .DropTable(name: "Entries")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "EntriesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .CreateTable(
                    name: "Entries",
                    columns: table =>
                        new
                        {
                            IndicatorId = table.Column<int>(type: "int", nullable: false),
                            Id = table
                                .Column<int>(type: "int", nullable: false)
                                .Annotation("SqlServer:Identity", "1, 1"),
                            EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                            Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                            StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                            UpdatedBy = table.Column<string>(
                                type: "nvarchar(max)",
                                nullable: false
                            ),
                            ValidFrom = table
                                .Column<DateTime>(type: "datetime2", nullable: false)
                                .Annotation("SqlServer:IsTemporal", true)
                                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                            ValidTo = table
                                .Column<DateTime>(type: "datetime2", nullable: false)
                                .Annotation("SqlServer:IsTemporal", true)
                                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom"),
                            Value = table.Column<double>(type: "float", nullable: false)
                        },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Entries", x => new { x.IndicatorId, x.Id });
                        table.ForeignKey(
                            name: "FK_Entries_Indicators_IndicatorId",
                            column: x => x.IndicatorId,
                            principalTable: "Indicators",
                            principalColumn: "Id",
                            onDelete: ReferentialAction.Cascade
                        );
                    }
                )
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "EntriesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");
        }
    }
}
