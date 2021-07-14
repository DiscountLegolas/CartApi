using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCore_Api.Migrations
{
    public partial class Deneme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Özelliks",
                columns: table => new
                {
                    ÖzellikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Özelliks", x => x.ÖzellikId);
                });
            migrationBuilder.CreateTable(
                name: "Favoris",
                columns: table => new
                {
                    FavoriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoris", x => x.FavoriId);
                    table.ForeignKey(
                        name: "FK_Favoris_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favoris_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HasÖzelliks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ÖzellikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HasÖzelliks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HasÖzelliks_Özelliks_ÖzellikId",
                        column: x => x.ÖzellikId,
                        principalTable: "Özelliks",
                        principalColumn: "ÖzellikId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HasÖzelliks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateIndex(
                name: "IX_Favoris_ProductId",
                table: "Favoris",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Favoris_UserId",
                table: "Favoris",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HasÖzelliks_ÖzellikId",
                table: "HasÖzelliks",
                column: "ÖzellikId");

            migrationBuilder.CreateIndex(
                name: "IX_HasÖzelliks_ProductId",
                table: "HasÖzelliks",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
