using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAsada.Migrations
{
    public partial class charge_add_column_charge_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChargeTypeId",
                table: "Charge",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsVATCharge",
                table: "Charge",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "VatRate",
                table: "Charge",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Charge_ChargeTypeId",
                table: "Charge",
                column: "ChargeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Charge_ChargeType_ChargeTypeId",
                table: "Charge",
                column: "ChargeTypeId",
                principalTable: "ChargeType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Charge_ChargeType_ChargeTypeId",
                table: "Charge");

            migrationBuilder.DropIndex(
                name: "IX_Charge_ChargeTypeId",
                table: "Charge");

            migrationBuilder.DropColumn(
                name: "ChargeTypeId",
                table: "Charge");

            migrationBuilder.DropColumn(
                name: "IsVATCharge",
                table: "Charge");

            migrationBuilder.DropColumn(
                name: "VatRate",
                table: "Charge");
        }
    }
}
