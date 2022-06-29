using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TakeGYM.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercise",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    BodyRegion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    IsPersonal = table.Column<bool>(nullable: false),
                    CPF = table.Column<string>(maxLength: 14, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    TeacherId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule_Teacher_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(maxLength: 14, nullable: true),
                    CEP = table.Column<string>(maxLength: 9, nullable: true),
                    Street = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    TeacherID = table.Column<string>(nullable: true),
                    HasPersonal = table.Column<bool>(nullable: false),
                    PersonalScheduleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Schedule_PersonalScheduleId",
                        column: x => x.PersonalScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Teacher_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teacher",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Alert",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PersonalID = table.Column<string>(nullable: true),
                    StudentID = table.Column<string>(nullable: true),
                    TrainingSheetObjective = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alert", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alert_Teacher_PersonalID",
                        column: x => x.PersonalID,
                        principalTable: "Teacher",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Alert_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingSheet",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    StudentID = table.Column<string>(nullable: true),
                    PersonalID = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    TrainingSheetObjective = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingSheet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingSheet_Teacher_PersonalID",
                        column: x => x.PersonalID,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainingSheet_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exercise_Trainingsheet",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    NumbersOfSet = table.Column<int>(nullable: false),
                    NumbersIteration = table.Column<int>(nullable: false),
                    ExerciseId = table.Column<string>(nullable: true),
                    TrainingsheetId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercise_Trainingsheet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercise_Trainingsheet_TrainingSheet_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "TrainingSheet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exercise_Trainingsheet_Exercise_TrainingsheetId",
                        column: x => x.TrainingsheetId,
                        principalTable: "Exercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_Exercise_Trainingsheet_ExerciseId",
                table: "Exercise_Trainingsheet",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_Trainingsheet_TrainingsheetId",
                table: "Exercise_Trainingsheet",
                column: "TrainingsheetId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_TeacherId",
                table: "Schedule",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_PersonalScheduleId",
                table: "Student",
                column: "PersonalScheduleId");


            migrationBuilder.CreateIndex(
                name: "IX_Student_TeacherID",
                table: "Student",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_Phone",
                table: "Teacher",
                column: "Phone",
                unique: true,
                filter: "[Phone] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSheet_PersonalID",
                table: "TrainingSheet",
                column: "PersonalID");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSheet_StudentID",
                table: "TrainingSheet",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alert");

            migrationBuilder.DropTable(
                name: "Exercise_Trainingsheet");

            migrationBuilder.DropTable(
                name: "TrainingSheet");

            migrationBuilder.DropTable(
                name: "Exercise");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
