using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAsada.Migrations
{
    public partial class cargos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        { 
            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_Contract_ContractId",
                table: "Receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_Measurement_MeasurementId",
                table: "Receipt");

            migrationBuilder.AlterColumn<int>(
                name: "MeasurementId",
                table: "Receipt",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ContractId",
                table: "Receipt",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MeasurementId",
                table: "Measurement",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_Contract_ContractId",
                table: "Receipt",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_Measurement_MeasurementId",
                table: "Receipt",
                column: "MeasurementId",
                principalTable: "Measurement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_Contract_ContractId",
                table: "Receipt");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipt_Measurement_MeasurementId",
                table: "Receipt");

            migrationBuilder.DropColumn(
                name: "MeasurementId",
                table: "Measurement");

            migrationBuilder.AlterColumn<int>(
                name: "MeasurementId",
                table: "Receipt",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ContractId",
                table: "Receipt",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_Contract_ContractId",
                table: "Receipt",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipt_Measurement_MeasurementId",
                table: "Receipt",
                column: "MeasurementId",
                principalTable: "Measurement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
