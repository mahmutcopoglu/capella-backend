using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig_19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesClassifications_Categories_CategoryId",
                table: "CategoriesClassifications");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesClassifications_Classifications_ClassificationId",
                table: "CategoriesClassifications");

            migrationBuilder.RenameColumn(
                name: "ClassificationId",
                table: "CategoriesClassifications",
                newName: "ClassificationsId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "CategoriesClassifications",
                newName: "CategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoriesClassifications_ClassificationId",
                table: "CategoriesClassifications",
                newName: "IX_CategoriesClassifications_ClassificationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesClassifications_Categories_CategoriesId",
                table: "CategoriesClassifications",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesClassifications_Classifications_ClassificationsId",
                table: "CategoriesClassifications",
                column: "ClassificationsId",
                principalTable: "Classifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesClassifications_Categories_CategoriesId",
                table: "CategoriesClassifications");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoriesClassifications_Classifications_ClassificationsId",
                table: "CategoriesClassifications");

            migrationBuilder.RenameColumn(
                name: "ClassificationsId",
                table: "CategoriesClassifications",
                newName: "ClassificationId");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "CategoriesClassifications",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoriesClassifications_ClassificationsId",
                table: "CategoriesClassifications",
                newName: "IX_CategoriesClassifications_ClassificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesClassifications_Categories_CategoryId",
                table: "CategoriesClassifications",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriesClassifications_Classifications_ClassificationId",
                table: "CategoriesClassifications",
                column: "ClassificationId",
                principalTable: "Classifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
