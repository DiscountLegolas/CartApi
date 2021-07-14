using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNetCore_Api.Migrations
{
    public partial class ProductRearrange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "OriginalPrice",
                table: "Products",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
