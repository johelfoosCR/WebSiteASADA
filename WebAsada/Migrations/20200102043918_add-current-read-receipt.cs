using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAsada.Migrations
{
    public partial class addcurrentreadreceipt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LastRead",
                table: "Receipt",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastRead",
                table: "Receipt");
        }
    }
}
