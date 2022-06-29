using Microsoft.EntityFrameworkCore.Migrations;

namespace TakeGYM.Migrations
{
    public partial class AlterColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Teacher_TeacherID",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "TeacherID",
                table: "Student",
                newName: "TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_TeacherID",
                table: "Student",
                newName: "IX_Student_TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Teacher_TeacherId",
                table: "Student",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Teacher_TeacherId",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Student",
                newName: "TeacherID");

            migrationBuilder.RenameIndex(
                name: "IX_Student_TeacherId",
                table: "Student",
                newName: "IX_Student_TeacherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Teacher_TeacherID",
                table: "Student",
                column: "TeacherID",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
