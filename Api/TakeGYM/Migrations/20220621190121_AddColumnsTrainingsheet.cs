using Microsoft.EntityFrameworkCore.Migrations;

namespace TakeGYM.Migrations
{
    public partial class AddColumnsTrainingsheet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StudentID",
                table: "TrainingSheet",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSheet_StudentID",
                table: "TrainingSheet",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingSheet_Student_StudentID",
                table: "TrainingSheet",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingSheet_Student_StudentID",
                table: "TrainingSheet");

            migrationBuilder.DropIndex(
                name: "IX_TrainingSheet_StudentID",
                table: "TrainingSheet");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "TrainingSheet");
        }
    }
}
