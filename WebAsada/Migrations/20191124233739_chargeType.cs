using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAsada.Migrations
{
    public partial class chargeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CubicMeterFrom",
                table: "Charge",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CubicMeterTo",
                table: "Charge",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "IsWaterConsume",
                table: "Charge",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ChargeType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RegisterUserId = table.Column<string>(nullable: true),
                    RegisterDatime = table.Column<DateTime>(nullable: false),
                    UpdateUserId = table.Column<string>(nullable: true),
                    UpdateDateTime = table.Column<DateTime>(nullable: false),
                    ShortDesc = table.Column<string>(nullable: true),
                    LongDesc = table.Column<string>(nullable: true),
                    Nemotecnico = table.Column<string>(nullable: true),
                    OfficialId = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    ChargeTypeCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChargeType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChargeType_AspNetUsers_RegisterUserId",
                        column: x => x.RegisterUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChargeType_AspNetUsers_UpdateUserId",
                        column: x => x.UpdateUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChargeType_RegisterUserId",
                table: "ChargeType",
                column: "RegisterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChargeType_UpdateUserId",
                table: "ChargeType",
                column: "UpdateUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChargeType");

            migrationBuilder.DropColumn(
                name: "CubicMeterFrom",
                table: "Charge");

            migrationBuilder.DropColumn(
                name: "CubicMeterTo",
                table: "Charge");

            migrationBuilder.DropColumn(
                name: "IsWaterConsume",
                table: "Charge");
        }
    }
}
