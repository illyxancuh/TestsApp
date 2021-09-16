using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProj.DataAccess.Migrations
{
    public partial class AddPercentageToPassColumnToTestsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PercentageToPass",
                table: "Tests",
                type: "int",
                nullable: false,
                defaultValue: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PercentageToPass",
                table: "Tests");
        }
    }
}
