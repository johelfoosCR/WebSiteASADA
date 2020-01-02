using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAsada.Migrations
{
    public partial class receiptItemsTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptItem_Charge_ChargeId",
                table: "ReceiptItem");

            migrationBuilder.DropIndex(
                name: "IX_ReceiptItem_ChargeId",
                table: "ReceiptItem");

            migrationBuilder.DropColumn(
                name: "ChargeId",
                table: "ReceiptItem");

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "ReceiptItem",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ReceiptItem",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "VatAmount",
                table: "ReceiptItem",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "ReceiptItem");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ReceiptItem");

            migrationBuilder.DropColumn(
                name: "VatAmount",
                table: "ReceiptItem");

            migrationBuilder.AddColumn<int>(
                name: "ChargeId",
                table: "ReceiptItem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptItem_ChargeId",
                table: "ReceiptItem",
                column: "ChargeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptItem_Charge_ChargeId",
                table: "ReceiptItem",
                column: "ChargeId",
                principalTable: "Charge",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
