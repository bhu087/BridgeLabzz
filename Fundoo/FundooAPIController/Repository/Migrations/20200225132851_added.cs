using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Registers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Registers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "Registers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Salary",
                table: "Registers",
                nullable: true);
        }
    }
}
