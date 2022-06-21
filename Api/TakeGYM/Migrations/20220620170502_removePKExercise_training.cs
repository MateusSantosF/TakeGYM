using Microsoft.EntityFrameworkCore.Migrations;

namespace TakeGYM.Migrations
{
    public partial class removePKExercise_training : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Exercise_Trainingsheet_ID",
                table: "Exercise_Trainingsheet");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Exercise_Trainingsheet");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_Trainingsheet_ExerciseID1",
               table: "Exercise_Trainingsheet"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Trainingsheet_Exercise_ExerciseID1",
                table: "Exercise_Trainingsheet"
            );

            migrationBuilder.DropColumn(
               name: "ExerciseID1",
               table: "Exercise_Trainingsheet"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ID",
                table: "Exercise_Trainingsheet",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Exercise_Trainingsheet_ID",
                table: "Exercise_Trainingsheet",
                column: "ID");
        }
    }
}
