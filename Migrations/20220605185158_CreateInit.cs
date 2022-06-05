using Microsoft.EntityFrameworkCore.Migrations;

namespace testAPI.Migrations
{
    public partial class CreateInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Buyer_BuyerId",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_SalesPoints_SalesPointId",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleData_Products_ProductId",
                table: "SaleData");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleData_Sale_SaleId",
                table: "SaleData");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesIds_Buyer_BuyerId",
                table: "SalesIds");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesIds_Sale_SaleId",
                table: "SalesIds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleData",
                table: "SaleData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sale",
                table: "Sale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buyer",
                table: "Buyer");

            migrationBuilder.RenameTable(
                name: "SaleData",
                newName: "SalesData");

            migrationBuilder.RenameTable(
                name: "Sale",
                newName: "Sales");

            migrationBuilder.RenameTable(
                name: "Buyer",
                newName: "Buyers");

            migrationBuilder.RenameIndex(
                name: "IX_SaleData_SaleId",
                table: "SalesData",
                newName: "IX_SalesData_SaleId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleData_ProductId",
                table: "SalesData",
                newName: "IX_SalesData_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Sale_SalesPointId",
                table: "Sales",
                newName: "IX_Sales_SalesPointId");

            migrationBuilder.RenameIndex(
                name: "IX_Sale_BuyerId",
                table: "Sales",
                newName: "IX_Sales_BuyerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalesData",
                table: "SalesData",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sales",
                table: "Sales",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buyers",
                table: "Buyers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Buyers_BuyerId",
                table: "Sales",
                column: "BuyerId",
                principalTable: "Buyers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_SalesPoints_SalesPointId",
                table: "Sales",
                column: "SalesPointId",
                principalTable: "SalesPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesData_Products_ProductId",
                table: "SalesData",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesData_Sales_SaleId",
                table: "SalesData",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesIds_Buyers_BuyerId",
                table: "SalesIds",
                column: "BuyerId",
                principalTable: "Buyers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesIds_Sales_SaleId",
                table: "SalesIds",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Buyers_BuyerId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_SalesPoints_SalesPointId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesData_Products_ProductId",
                table: "SalesData");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesData_Sales_SaleId",
                table: "SalesData");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesIds_Buyers_BuyerId",
                table: "SalesIds");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesIds_Sales_SaleId",
                table: "SalesIds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalesData",
                table: "SalesData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sales",
                table: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buyers",
                table: "Buyers");

            migrationBuilder.RenameTable(
                name: "SalesData",
                newName: "SaleData");

            migrationBuilder.RenameTable(
                name: "Sales",
                newName: "Sale");

            migrationBuilder.RenameTable(
                name: "Buyers",
                newName: "Buyer");

            migrationBuilder.RenameIndex(
                name: "IX_SalesData_SaleId",
                table: "SaleData",
                newName: "IX_SaleData_SaleId");

            migrationBuilder.RenameIndex(
                name: "IX_SalesData_ProductId",
                table: "SaleData",
                newName: "IX_SaleData_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_SalesPointId",
                table: "Sale",
                newName: "IX_Sale_SalesPointId");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_BuyerId",
                table: "Sale",
                newName: "IX_Sale_BuyerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleData",
                table: "SaleData",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sale",
                table: "Sale",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buyer",
                table: "Buyer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Buyer_BuyerId",
                table: "Sale",
                column: "BuyerId",
                principalTable: "Buyer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_SalesPoints_SalesPointId",
                table: "Sale",
                column: "SalesPointId",
                principalTable: "SalesPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleData_Products_ProductId",
                table: "SaleData",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleData_Sale_SaleId",
                table: "SaleData",
                column: "SaleId",
                principalTable: "Sale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesIds_Buyer_BuyerId",
                table: "SalesIds",
                column: "BuyerId",
                principalTable: "Buyer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesIds_Sale_SaleId",
                table: "SalesIds",
                column: "SaleId",
                principalTable: "Sale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
