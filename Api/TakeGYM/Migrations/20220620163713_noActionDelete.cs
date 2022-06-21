using Microsoft.EntityFrameworkCore.Migrations;

namespace TakeGYM.Migrations
{
    public partial class noActionDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alert_Teacher_PersonalID",
                table: "Alert");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Teacher_TeacherID",
                table: "Student");

            migrationBuilder.AddForeignKey(
                name: "FK_Alert_Teacher_PersonalID",
                table: "Alert",
                column: "PersonalID",
                principalTable: "Teacher",
                principalColumn: "TeacherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Teacher_TeacherID",
                table: "Student",
                column: "TeacherID",
                principalTable: "Teacher",
                principalColumn: "TeacherID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alert_Teacher_PersonalID",
                table: "Alert");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Teacher_TeacherID",
                table: "Student");

            migrationBuilder.AddForeignKey(
                name: "FK_Alert_Teacher_PersonalID",
                table: "Alert",
                column: "PersonalID",
                principalTable: "Teacher",
                principalColumn: "TeacherID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Teacher_TeacherID",
                table: "Student",
                column: "TeacherID",
                principalTable: "Teacher",
                principalColumn: "TeacherID",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
