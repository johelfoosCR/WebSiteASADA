using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAsada.Migrations
{
    public partial class receiptItemsDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptItem_Receipt_ReceiptId",
                table: "ReceiptItem");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptItem_Receipt_ReceiptId",
                table: "ReceiptItem",
                column: "ReceiptId",
                principalTable: "Receipt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptItem_Receipt_ReceiptId",
                table: "ReceiptItem");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptItem_Receipt_ReceiptId",
                table: "ReceiptItem",
                column: "ReceiptId",
                principalTable: "Receipt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
