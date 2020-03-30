using Microsoft.EntityFrameworkCore.Migrations;

namespace CoollabTech.Infra.Data.Migrations
{
    public partial class VacharEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Citizens",
                type: "varchar(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Citizens",
                type: "char(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1)");
        }
    }
}
