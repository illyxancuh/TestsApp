using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProj.DataAccess.Migrations
{
    public partial class AddPositionColumnToQuestionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Questions");
        }
    }
}
