using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OurCleanFuture.Data.Migrations
{
    public partial class ActionExternalStatusUpdatedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExternalStatusUpdatedBy",
                table: "Actions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ExternalStatusUpdatedDate",
                table: "Actions",
                type: "datetimeoffset",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalStatusUpdatedBy",
                table: "Actions")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ActionsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null);

            migrationBuilder.DropColumn(
                name: "ExternalStatusUpdatedDate",
                table: "Actions")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "ActionsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null);
        }
    }
}
