using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations.Migrations
{
    public partial class Add_Color_To_ConflictTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "ConflictTeam",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "ConflictTeam");
        }
    }
}
