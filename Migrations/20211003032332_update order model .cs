using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop_API.Migrations
{
    public partial class updateordermodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_orderModel_OrderModelId",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_OrderModelId",
                table: "product");

            migrationBuilder.DropColumn(
                name: "OrderModelId",
                table: "product");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "orderModel",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "orderModel",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "orderModel",
                newName: "Address");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "orderModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderTime",
                table: "orderModel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "orderDetailsModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderDetailsModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orderDetailsModel_orderModel_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orderModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderDetailsModel_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderDetailsModel_OrderId",
                table: "orderDetailsModel",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetailsModel_ProductId",
                table: "orderDetailsModel",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderDetailsModel");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "orderModel");

            migrationBuilder.DropColumn(
                name: "OrderTime",
                table: "orderModel");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "orderModel",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "orderModel",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "orderModel",
                newName: "address");

            migrationBuilder.AddColumn<int>(
                name: "OrderModelId",
                table: "product",
                type: "int",
                nullable: true);

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
    }
}
