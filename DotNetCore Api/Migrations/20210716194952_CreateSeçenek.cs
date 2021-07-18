using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCore_Api.Migrations
{
    public partial class CreateSeçenek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seçenekler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seçenekler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seçenekler_Filters_FilterId",
                        column: x => x.FilterId,
                        principalTable: "Filters",
                        principalColumn: "FilterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seçenekler_Özelliks_Id",
                        column: x => x.Id,
                        principalTable: "Özelliks",
                        principalColumn: "ÖzellikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seçenekler_FilterId",
                table: "Seçenekler",
                column: "FilterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
