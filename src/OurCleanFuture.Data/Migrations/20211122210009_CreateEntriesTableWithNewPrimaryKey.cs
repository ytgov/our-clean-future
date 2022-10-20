using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OurCleanFuture.Data.Migrations
{
    public partial class CreateEntriesTableWithNewPrimaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .CreateTable(
                    name: "Entries",
                    columns: table =>
                        new
                        {
                            Id = table.Column<int>(type: "int", nullable: false),
                            StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                            IndicatorId = table.Column<int>(type: "int", nullable: false),
                            EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                            Value = table.Column<double>(type: "float", nullable: false),
                            Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom")
                        },
                    constraints: table =>
                    {
                        table.PrimaryKey(
                            "PK_Entries",
                            x => new { x.IndicatorId, x.Id, x.StartDate }
                        );
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .DropTable(name: "Entries")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "EntriesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");
        }
    }
}
