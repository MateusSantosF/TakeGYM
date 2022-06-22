using Microsoft.EntityFrameworkCore.Migrations;

namespace TakeGYM.Migrations
{
    public partial class FixedModelCreatingTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Trainingsheet_Exercise_ExerciseId1",
                table: "Exercise_Trainingsheet");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_Trainingsheet_ExerciseId1",
                table: "Exercise_Trainingsheet");

            migrationBuilder.DropColumn(
                name: "ExerciseId1",
                table: "Exercise_Trainingsheet");

            migrationBuilder.AlterColumn<string>(
                name: "TrainingsheetId",
                table: "Exercise_Trainingsheet",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_Trainingsheet_TrainingsheetId",
                table: "Exercise_Trainingsheet",
                column: "TrainingsheetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Trainingsheet_Exercise_TrainingsheetId",
                table: "Exercise_Trainingsheet",
                column: "TrainingsheetId",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Trainingsheet_Exercise_TrainingsheetId",
                table: "Exercise_Trainingsheet");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_Trainingsheet_TrainingsheetId",
                table: "Exercise_Trainingsheet");

            migrationBuilder.AlterColumn<string>(
                name: "TrainingsheetId",
                table: "Exercise_Trainingsheet",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExerciseId1",
                table: "Exercise_Trainingsheet",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_Trainingsheet_ExerciseId1",
                table: "Exercise_Trainingsheet",
                column: "ExerciseId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Trainingsheet_Exercise_ExerciseId1",
                table: "Exercise_Trainingsheet",
                column: "ExerciseId1",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
