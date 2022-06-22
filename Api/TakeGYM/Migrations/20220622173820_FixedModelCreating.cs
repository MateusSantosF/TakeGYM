using Microsoft.EntityFrameworkCore.Migrations;

namespace TakeGYM.Migrations
{
    public partial class FixedModelCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Trainingsheet_TrainingSheet_ExerciseId",
                table: "Exercise_Trainingsheet");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Trainingsheet_Exercise_ExerciseId1",
                table: "Exercise_Trainingsheet");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Exercise_Trainingsheet_Id",
                table: "Exercise_Trainingsheet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercise_Trainingsheet",
                table: "Exercise_Trainingsheet");

            migrationBuilder.AlterColumn<string>(
                name: "ExerciseId1",
                table: "Exercise_Trainingsheet",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "TrainingsheetId",
                table: "Exercise_Trainingsheet",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ExerciseId",
                table: "Exercise_Trainingsheet",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercise_Trainingsheet",
                table: "Exercise_Trainingsheet",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_Trainingsheet_ExerciseId",
                table: "Exercise_Trainingsheet",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Trainingsheet_TrainingSheet_ExerciseId",
                table: "Exercise_Trainingsheet",
                column: "ExerciseId",
                principalTable: "TrainingSheet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Trainingsheet_Exercise_ExerciseId1",
                table: "Exercise_Trainingsheet",
                column: "ExerciseId1",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Trainingsheet_TrainingSheet_ExerciseId",
                table: "Exercise_Trainingsheet");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Trainingsheet_Exercise_ExerciseId1",
                table: "Exercise_Trainingsheet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercise_Trainingsheet",
                table: "Exercise_Trainingsheet");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_Trainingsheet_ExerciseId",
                table: "Exercise_Trainingsheet");

            migrationBuilder.AlterColumn<string>(
                name: "TrainingsheetId",
                table: "Exercise_Trainingsheet",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExerciseId1",
                table: "Exercise_Trainingsheet",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExerciseId",
                table: "Exercise_Trainingsheet",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Exercise_Trainingsheet_Id",
                table: "Exercise_Trainingsheet",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercise_Trainingsheet",
                table: "Exercise_Trainingsheet",
                columns: new[] { "ExerciseId", "TrainingsheetId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Trainingsheet_TrainingSheet_ExerciseId",
                table: "Exercise_Trainingsheet",
                column: "ExerciseId",
                principalTable: "TrainingSheet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Trainingsheet_Exercise_ExerciseId1",
                table: "Exercise_Trainingsheet",
                column: "ExerciseId1",
                principalTable: "Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
