using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig_value : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassificationAttributeValues_Products_ProductId",
                table: "ClassificationAttributeValues");

            migrationBuilder.DropIndex(
                name: "IX_ClassificationAttributeValues_ProductId",
                table: "ClassificationAttributeValues");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ClassificationAttributeValues");

            migrationBuilder.CreateTable(
                name: "ProductClassificationAttributeValues",
                columns: table => new
                {
                    ClassificationAttributeValuesId = table.Column<int>(type: "integer", nullable: false),
                    ProductsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductClassificationAttributeValues", x => new { x.ClassificationAttributeValuesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_ProductClassificationAttributeValues_ClassificationAttribut~",
                        column: x => x.ClassificationAttributeValuesId,
                        principalTable: "ClassificationAttributeValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductClassificationAttributeValues_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductClassificationAttributeValues_ProductsId",
                table: "ProductClassificationAttributeValues",
                column: "ProductsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductClassificationAttributeValues");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ClassificationAttributeValues",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ClassificationAttributeValues_ProductId",
                table: "ClassificationAttributeValues",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassificationAttributeValues_Products_ProductId",
                table: "ClassificationAttributeValues",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
