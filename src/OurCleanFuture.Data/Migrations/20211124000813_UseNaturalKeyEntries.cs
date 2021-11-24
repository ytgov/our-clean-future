using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OurCleanFuture.Data.Migrations
{
    public partial class UseNaturalKeyEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Entries",
                table: "Entries")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "EntriesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Entries")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "EntriesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entries",
                table: "Entries",
                columns: new[] { "IndicatorId", "StartDate" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Entries",
                table: "Entries")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "EntriesHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "ValidTo")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "ValidFrom");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Entries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entries",
                table: "Entries",
                columns: new[] { "IndicatorId", "Id", "StartDate" });
        }
    }
}
