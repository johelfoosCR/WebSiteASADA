using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAsada.Migrations
{
    public partial class receiptItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReceiptItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegisterUserId = table.Column<string>(nullable: true),
                    RegisterDatime = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<string>(nullable: true),
                    UpdateDateTime = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ReceiptId = table.Column<int>(nullable: true),
                    ChargeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceiptItem_Charge_ChargeId",
                        column: x => x.ChargeId,
                        principalTable: "Charge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceiptItem_Receipt_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceiptItem_AspNetUsers_RegisterUserId",
                        column: x => x.RegisterUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReceiptItem_AspNetUsers_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptItem_ChargeId",
                table: "ReceiptItem",
                column: "ChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptItem_ReceiptId",
                table: "ReceiptItem",
                column: "ReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptItem_RegisterUserId",
                table: "ReceiptItem",
                column: "RegisterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptItem_UpdateUserId",
                table: "ReceiptItem",
                column: "UpdateUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceiptItem");
        }
    }
}
