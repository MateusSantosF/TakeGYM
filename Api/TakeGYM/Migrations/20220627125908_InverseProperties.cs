using Microsoft.EntityFrameworkCore.Migrations;

namespace TakeGYM.Migrations
{
    public partial class InverseProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Teacher_TeacherID",
                table: "Student");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Teacher_TeacherID",
                table: "Student",
                column: "TeacherID",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Teacher_TeacherID",
                table: "Student");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Teacher_TeacherID",
                table: "Student",
                column: "TeacherID",
                principalTable: "Teacher",
                principalColumn: "Id");
        }
    }
}
