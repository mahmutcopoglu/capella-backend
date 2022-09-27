using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig_16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesClassifications_Classification_ClassificationId",
                table: "CategoriesClassifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classification",
                table: "Classification");

            migrationBuilder.RenameTable(
                name: "Classification",
                newName: "Classifications");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classifications",
                table: "Classifications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesClassifications_Classifications_ClassificationId",
                table: "CategoriesClassifications",
                column: "ClassificationId",
                principalTable: "Classifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesClassifications_Classifications_ClassificationId",
                table: "CategoriesClassifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Classifications",
                table: "Classifications");

            migrationBuilder.RenameTable(
                name: "Classifications",
                newName: "Classification");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Classification",
                table: "Classification",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesClassifications_Classification_ClassificationId",
                table: "CategoriesClassifications",
                column: "ClassificationId",
                principalTable: "Classification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
