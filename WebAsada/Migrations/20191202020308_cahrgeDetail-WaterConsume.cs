using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAsada.Migrations
{
    public partial class cahrgeDetailWaterConsume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contract_WaterMeter_MeterId",
                table: "Contract");

            migrationBuilder.DropIndex(
                name: "IX_Contract_MeterId",
                table: "Contract");

            migrationBuilder.AddColumn<int>(
                name: "WaterMeterId",
                table: "Contract",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsWaterConsume",
                table: "ChargeType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Contract_WaterMeterId",
                table: "Contract",
                column: "WaterMeterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_WaterMeter_WaterMeterId",
                table: "Contract",
                column: "WaterMeterId",
                principalTable: "WaterMeter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contract_WaterMeter_WaterMeterId",
                table: "Contract");

            migrationBuilder.DropIndex(
                name: "IX_Contract_WaterMeterId",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "WaterMeterId",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "IsWaterConsume",
                table: "ChargeType");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_MeterId",
                table: "Contract",
                column: "MeterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_WaterMeter_MeterId",
                table: "Contract",
                column: "MeterId",
                principalTable: "WaterMeter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
