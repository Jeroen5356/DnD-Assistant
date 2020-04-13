using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations.Migrations
{
    public partial class Added_Level_To_Person : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Person",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Person");
        }
    }
}
