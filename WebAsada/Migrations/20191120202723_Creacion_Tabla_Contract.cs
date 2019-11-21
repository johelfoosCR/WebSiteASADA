using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAsada.Migrations
{
    public partial class Creacion_Tabla_Contract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        { 
            migrationBuilder.AddColumn<bool>(
                name: "DoubleBasicCharge",
                table: "Contract",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "EmissionDate",
                table: "Contract",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "InitialMeterRead",
                table: "Contract",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Contract",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MeterId",
                table: "Contract",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonsByEstateEstateId",
                table: "Contract",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonsByEstatePersonId",
                table: "Contract",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contract_MeterId",
                table: "Contract",
                column: "MeterId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_PersonsByEstateEstateId_PersonsByEstatePersonId",
                table: "Contract",
                columns: new[] { "PersonsByEstateEstateId", "PersonsByEstatePersonId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_WaterMeter_MeterId",
                table: "Contract",
                column: "MeterId",
                principalTable: "WaterMeter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_PersonsByEstate_PersonsByEstateEstateId_PersonsByEstatePersonId",
                table: "Contract",
                columns: new[] { "PersonsByEstateEstateId", "PersonsByEstatePersonId" },
                principalTable: "PersonsByEstate",
                principalColumns: new[] { "EstateId", "PersonId" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contract_WaterMeter_MeterId",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_PersonsByEstate_PersonsByEstateEstateId_PersonsByEstatePersonId",
                table: "Contract");

            migrationBuilder.DropIndex(
                name: "IX_Contract_MeterId",
                table: "Contract");

            migrationBuilder.DropIndex(
                name: "IX_Contract_PersonsByEstateEstateId_PersonsByEstatePersonId",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "DoubleBasicCharge",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "EmissionDate",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "InitialMeterRead",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "MeterId",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "PersonsByEstateEstateId",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "PersonsByEstatePersonId",
                table: "Contract");
             
        }
    }
}
