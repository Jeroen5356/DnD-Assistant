using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations.Migrations
{
    public partial class Added_CurrentAndMaxHealth_To_Person : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentHealth",
                table: "Person",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxHealth",
                table: "Person",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentHealth",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "MaxHealth",
                table: "Person");
        }
    }
}
