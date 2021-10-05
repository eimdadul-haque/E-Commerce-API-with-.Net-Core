using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop_API.Migrations
{
    public partial class updateordermodel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Qty",
                table: "orderDetailsModel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Qty",
                table: "orderDetailsModel");
        }
    }
}
