using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OurCleanFuture.Data.Migrations
{
    public partial class CascadeDeleteIndicatorToIndicatorLead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndicatorLead_Indicators_IndicatorId",
                table: "IndicatorLead");

            migrationBuilder.AddForeignKey(
                name: "FK_IndicatorLead_Indicators_IndicatorId",
                table: "IndicatorLead",
                column: "IndicatorId",
                principalTable: "Indicators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndicatorLead_Indicators_IndicatorId",
                table: "IndicatorLead");

            migrationBuilder.AddForeignKey(
                name: "FK_IndicatorLead_Indicators_IndicatorId",
                table: "IndicatorLead",
                column: "IndicatorId",
                principalTable: "Indicators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
