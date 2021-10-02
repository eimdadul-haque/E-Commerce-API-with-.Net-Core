using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop_API.Migrations
{
    public partial class addordermodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderModelId",
                table: "product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "orderModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_OrderModelId",
                table: "product",
                column: "OrderModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_product_orderModel_OrderModelId",
                table: "product",
                column: "OrderModelId",
                principalTable: "orderModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_orderModel_OrderModelId",
                table: "product");

            migrationBuilder.DropTable(
                name: "orderModel");

            migrationBuilder.DropIndex(
                name: "IX_product_OrderModelId",
                table: "product");

            migrationBuilder.DropColumn(
                name: "OrderModelId",
                table: "product");
        }
    }
}
