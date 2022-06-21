using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TakeGYM.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    ExerciseID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    BodyRegion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.ExerciseID);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    TeacherID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    IsPersonal = table.Column<bool>(nullable: false),
                    CPF = table.Column<string>(maxLength: 14, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.TeacherID);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    WorkScheduleID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    TeacherID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.WorkScheduleID);
                    table.ForeignKey(
                        name: "FK_Schedule_Teacher_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teacher",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    CPF = table.Column<string>(maxLength: 14, nullable: true),
                    CEP = table.Column<string>(maxLength: 9, nullable: true),
                    Street = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    TeacherID = table.Column<long>(nullable: true),
                    HasPersonal = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Student_Teacher_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teacher",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "TrainingSheet",
                columns: table => new
                {
                    TraningSheetID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalID = table.Column<long>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    TrainingSheetObjective = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingSheet", x => x.TraningSheetID);
                    table.ForeignKey(
                        name: "FK_TrainingSheet_Teacher_PersonalID",
                        column: x => x.PersonalID,
                        principalTable: "Teacher",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alert",
                columns: table => new
                {
                    PersonalAlertID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalID = table.Column<long>(nullable: false),
                    StudentID = table.Column<long>(nullable: false),
                    TrainingSheetObjective = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alert", x => x.PersonalAlertID);
                    table.ForeignKey(
                        name: "FK_Alert_Teacher_PersonalID",
                        column: x => x.PersonalID,
                        principalTable: "Teacher",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alert_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercise_Trainingsheet",
                columns: table => new
                {
                    ExerciseID = table.Column<long>(nullable: false),
                    TrainingsheetID = table.Column<long>(nullable: false),
                    NumbersOfSet = table.Column<int>(nullable: false),
                    NumbersIteration = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise_Trainingsheet", x => new { x.ExerciseID, x.TrainingsheetID });
                    table.ForeignKey(
                        name: "FK_Exercise_Trainingsheet_TrainingSheet_ExerciseID",
                        column: x => x.TrainingsheetID,
                        principalTable: "TrainingSheet",
                        principalColumn: "TraningSheetID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exercise_Trainingsheet_Exercise_ExerciseID1",
                        column: x => x.ExerciseID,
                        principalTable: "Exercise",
                        principalColumn: "ExerciseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alert_PersonalID",
                table: "Alert",
                column: "PersonalID");

            migrationBuilder.CreateIndex(
                name: "IX_Alert_StudentID",
                table: "Alert",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_Trainingsheet_ExerciseID1",
                table: "Exercise_Trainingsheet",
                column: "ExerciseID1");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_TeacherID",
                table: "Schedule",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_TeacherID",
                table: "Student",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSheet_PersonalID",
                table: "TrainingSheet",
                column: "PersonalID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alert");

            migrationBuilder.DropTable(
                name: "Exercise_Trainingsheet");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "TrainingSheet");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
