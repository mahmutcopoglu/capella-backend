using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig_31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesUnitTypes_Classifications_ClassificationsId",
                table: "CategoriesUnitTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesUnitTypes_Units_UnitTypesId",
                table: "CategoriesUnitTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriesUnitTypes",
                table: "CategoriesUnitTypes");

            migrationBuilder.RenameTable(
                name: "CategoriesUnitTypes",
                newName: "ClassificationsUnits");

            migrationBuilder.RenameColumn(
                name: "UnitTypesId",
                table: "ClassificationsUnits",
                newName: "UnitsId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoriesUnitTypes_UnitTypesId",
                table: "ClassificationsUnits",
                newName: "IX_ClassificationsUnits_UnitsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassificationsUnits",
                table: "ClassificationsUnits",
                columns: new[] { "ClassificationsId", "UnitsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ClassificationsUnits_Classifications_ClassificationsId",
                table: "ClassificationsUnits",
                column: "ClassificationsId",
                principalTable: "Classifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassificationsUnits_Units_UnitsId",
                table: "ClassificationsUnits",
                column: "UnitsId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassificationsUnits_Classifications_ClassificationsId",
                table: "ClassificationsUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassificationsUnits_Units_UnitsId",
                table: "ClassificationsUnits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassificationsUnits",
                table: "ClassificationsUnits");

            migrationBuilder.RenameTable(
                name: "ClassificationsUnits",
                newName: "CategoriesUnitTypes");

            migrationBuilder.RenameColumn(
                name: "UnitsId",
                table: "CategoriesUnitTypes",
                newName: "UnitTypesId");

            migrationBuilder.RenameIndex(
                name: "IX_ClassificationsUnits_UnitsId",
                table: "CategoriesUnitTypes",
                newName: "IX_CategoriesUnitTypes_UnitTypesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriesUnitTypes",
                table: "CategoriesUnitTypes",
                columns: new[] { "ClassificationsId", "UnitTypesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesUnitTypes_Classifications_ClassificationsId",
                table: "CategoriesUnitTypes",
                column: "ClassificationsId",
                principalTable: "Classifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesUnitTypes_Units_UnitTypesId",
                table: "CategoriesUnitTypes",
                column: "UnitTypesId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
