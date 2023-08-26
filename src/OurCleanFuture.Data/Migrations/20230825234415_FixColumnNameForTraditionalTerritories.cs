using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OurCleanFuture.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixColumnNameForTraditionalTerritories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionIndigenousGroup_IndigenousGroups_UndertakenInTraditionalTerritoriesOfId",
                table: "ActionIndigenousGroup");

            migrationBuilder.RenameColumn(
                name: "UndertakenInTraditionalTerritoriesOfId",
                table: "ActionIndigenousGroup",
                newName: "UndertakenInTheTraditionalTerritoriesOfId");

            migrationBuilder.RenameIndex(
                name: "IX_ActionIndigenousGroup_UndertakenInTraditionalTerritoriesOfId",
                table: "ActionIndigenousGroup",
                newName: "IX_ActionIndigenousGroup_UndertakenInTheTraditionalTerritoriesOfId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionIndigenousGroup_IndigenousGroups_UndertakenInTheTraditionalTerritoriesOfId",
                table: "ActionIndigenousGroup",
                column: "UndertakenInTheTraditionalTerritoriesOfId",
                principalTable: "IndigenousGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionIndigenousGroup_IndigenousGroups_UndertakenInTheTraditionalTerritoriesOfId",
                table: "ActionIndigenousGroup");

            migrationBuilder.RenameColumn(
                name: "UndertakenInTheTraditionalTerritoriesOfId",
                table: "ActionIndigenousGroup",
                newName: "UndertakenInTraditionalTerritoriesOfId");

            migrationBuilder.RenameIndex(
                name: "IX_ActionIndigenousGroup_UndertakenInTheTraditionalTerritoriesOfId",
                table: "ActionIndigenousGroup",
                newName: "IX_ActionIndigenousGroup_UndertakenInTraditionalTerritoriesOfId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionIndigenousGroup_IndigenousGroups_UndertakenInTraditionalTerritoriesOfId",
                table: "ActionIndigenousGroup",
                column: "UndertakenInTraditionalTerritoriesOfId",
                principalTable: "IndigenousGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
