using Microsoft.EntityFrameworkCore.Migrations;

namespace CoollabTech.Infra.Data.Migrations
{
    public partial class NovosDadosCidadão : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Citizens",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Excluded",
                table: "Citizens",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Citizens");

            migrationBuilder.DropColumn(
                name: "Excluded",
                table: "Citizens");
        }
    }
}
