using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mig_33 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassificationsUnits");

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "Classifications",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClassificationAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UnitId = table.Column<int>(type: "integer", nullable: false),
                    ClassificationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassificationAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassificationAttributes_Classifications_ClassificationId",
                        column: x => x.ClassificationId,
                        principalTable: "Classifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassificationAttributes_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductsCategories",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "integer", nullable: false),
                    ProductsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsCategories", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_ProductsCategories_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductsCategories_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassificationAttributeValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    ClassificationAttributeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassificationAttributeValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassificationAttributeValues_ClassificationAttributes_Clas~",
                        column: x => x.ClassificationAttributeId,
                        principalTable: "ClassificationAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassificationAttributeValues_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classifications_UnitId",
                table: "Classifications",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassificationAttributes_ClassificationId",
                table: "ClassificationAttributes",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassificationAttributes_UnitId",
                table: "ClassificationAttributes",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassificationAttributeValues_ClassificationAttributeId",
                table: "ClassificationAttributeValues",
                column: "ClassificationAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassificationAttributeValues_ProductId",
                table: "ClassificationAttributeValues",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsCategories_ProductsId",
                table: "ProductsCategories",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classifications_Units_UnitId",
                table: "Classifications",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classifications_Units_UnitId",
                table: "Classifications");

            migrationBuilder.DropTable(
                name: "ClassificationAttributeValues");

            migrationBuilder.DropTable(
                name: "ProductsCategories");

            migrationBuilder.DropTable(
                name: "ClassificationAttributes");

            migrationBuilder.DropIndex(
                name: "IX_Classifications_UnitId",
                table: "Classifications");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Classifications");

            migrationBuilder.CreateTable(
                name: "ClassificationsUnits",
                columns: table => new
                {
                    ClassificationsId = table.Column<int>(type: "integer", nullable: false),
                    UnitsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassificationsUnits", x => new { x.ClassificationsId, x.UnitsId });
                    table.ForeignKey(
                        name: "FK_ClassificationsUnits_Classifications_ClassificationsId",
                        column: x => x.ClassificationsId,
                        principalTable: "Classifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassificationsUnits_Units_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassificationsUnits_UnitsId",
                table: "ClassificationsUnits",
                column: "UnitsId");
        }
    }
}
