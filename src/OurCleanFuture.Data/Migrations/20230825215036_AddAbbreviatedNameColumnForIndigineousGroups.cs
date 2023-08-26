using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OurCleanFuture.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAbbreviatedNameColumnForIndigineousGroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "IndigenousGroups",
                newName: "FullName");

            migrationBuilder.AddColumn<string>(
                name: "AbbreviatedName",
                table: "IndigenousGroups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AbbreviatedName",
                table: "IndigenousGroups");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "IndigenousGroups",
                newName: "Name");
        }
    }
}
