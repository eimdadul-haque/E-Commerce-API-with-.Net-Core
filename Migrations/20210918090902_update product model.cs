using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop_API.Migrations
{
    public partial class updateproductmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_productType_productTypeId",
                table: "product");

            migrationBuilder.AlterColumn<int>(
                name: "productTypeId",
                table: "product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "productName",
                table: "product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_product_productType_productTypeId",
                table: "product",
                column: "productTypeId",
                principalTable: "productType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_productType_productTypeId",
                table: "product");

            migrationBuilder.AlterColumn<int>(
                name: "productTypeId",
                table: "product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "productName",
                table: "product",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_product_productType_productTypeId",
                table: "product",
                column: "productTypeId",
                principalTable: "productType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
