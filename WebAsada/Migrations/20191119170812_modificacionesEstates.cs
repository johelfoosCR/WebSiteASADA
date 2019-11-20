using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAsada.Migrations
{
    public partial class modificacionesEstates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "Estate",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExactAddress",
                table: "Estate",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alias",
                table: "Estate");

            migrationBuilder.DropColumn(
                name: "ExactAddress",
                table: "Estate");
        }
    }
}
