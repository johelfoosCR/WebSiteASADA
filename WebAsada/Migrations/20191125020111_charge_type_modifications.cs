using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAsada.Migrations
{
    public partial class charge_type_modifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVATCharge",
                table: "Charge");

            migrationBuilder.DropColumn(
                name: "VatRate",
                table: "Charge");

            migrationBuilder.AddColumn<bool>(
                name: "IsVATCharge",
                table: "ChargeType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "VatRate",
                table: "ChargeType",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVATCharge",
                table: "ChargeType");

            migrationBuilder.DropColumn(
                name: "VatRate",
                table: "ChargeType");

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
        }
    }
}
