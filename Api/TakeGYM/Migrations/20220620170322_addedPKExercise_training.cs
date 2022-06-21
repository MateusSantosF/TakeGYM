using Microsoft.EntityFrameworkCore.Migrations;

namespace TakeGYM.Migrations
{
    public partial class addedPKExercise_training : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ID",
                table: "Exercise_Trainingsheet",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Exercise_Trainingsheet_ID",
                table: "Exercise_Trainingsheet",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Exercise_Trainingsheet_ID",
                table: "Exercise_Trainingsheet");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Exercise_Trainingsheet");
        }
    }
}
