using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop_API.Migrations
{
    public partial class updateproductinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "productPrice",
                table: "product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "productPrice",
                table: "product");
        }
    }
}
