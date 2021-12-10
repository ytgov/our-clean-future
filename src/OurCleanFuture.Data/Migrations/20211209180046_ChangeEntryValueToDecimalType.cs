using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OurCleanFuture.Data.Migrations
{
    public partial class ChangeEntryValueToDecimalType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "Entries",
                type: "decimal(22,6)",
                precision: 22,
                scale: 6,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Value",
                table: "Entries",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(22,6)",
                oldPrecision: 22,
                oldScale: 6);
        }
    }
}